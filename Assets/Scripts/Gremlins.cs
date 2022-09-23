using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Gremlins : MonoBehaviour
{
    #region Important_variables

    public float speed; 

    public int jumpAmount;

    private Rigidbody2D rb;

    public bool direction = false;

    public string gremlin_type;
    
    private string[] gremlins = new string[]{"Default", "Digger", "Jumper", "Stone"};

    private float jumpTimer = 0;

    static public bool isDigging = false;

    private float diggingTimer = 2;

    public float horizontalVelocity; 

    public Animator animator;

    private int collisionCount;

    private int CountOfDiggs;

    public bool is_Clicked = false;

    public static int gremlinDead;

    [SerializeField]
    public GameObject stoneGenerated;

    [SerializeField]
    public GameObject stoneGeneratedReverse;

    [SerializeField]
    public GameObject Arrow;

    #endregion

    void OnMouseDown()
    {
        if (InGameController.click_Timer == 0)
        {
            Debug.Log("Click");
            is_Clicked = true;
            InGameController.click_Timer = 10;
            Debug.Log(InGameController.click_Timer);
            Arrow.SetActive(true);
        }
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InGameController.click_Timer = Math.Max(0, InGameController.click_Timer - Time.deltaTime);

        if (InGameController.click_Timer == 0)
        {
            is_Clicked = false;
            Arrow.SetActive(false);
        }


        StartCoroutine(CalculateHorizontalVelocity());

        Vector2 pos1 = transform.position;
        
        gremlin_Ability(pos1);

        diggingTimer = Math.Max(0, diggingTimer - Time.deltaTime);

        if (diggingTimer == 0) {
            isDigging = false;
            diggingTimer = 2;
        }

        if(direction)
        {
                pos1.x += speed * Time.deltaTime;
        }
        else
        {
                pos1.x -= speed * Time.deltaTime;
        }
        

        #region Dying Method
        if (CountOfDiggs >= 1)
        {
            StartCoroutine(Death());

            animator.SetFloat("Death", 1);
        }

        IEnumerator Death()
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
            gremlinDead += 1;
        }

            #endregion

            transform.position = pos1;

        #region Animator Speed

        IEnumerator CalculateHorizontalVelocity()
        {
            Vector3 lastPosition = transform.position;
            yield return new WaitForFixedUpdate();
            horizontalVelocity = (lastPosition - transform.position).magnitude / Time.deltaTime;

        }

        animator.SetFloat("AnimateSpeed", Mathf.Abs(horizontalVelocity));

        #endregion

        #region Animator Direction
        if (direction == false)
        {
            animator.SetFloat("ReverseDirection", 1);
        }
        if (direction == true)
        {
            animator.SetFloat("ReverseDirection", -1);
        }

        #endregion 

        #region Animator Dig
        if (isDigging == true)
        {
            animator.SetFloat("Dig", 1);
        }
        if (isDigging == false)
        {
            animator.SetFloat("Dig", -1);
        }

        #endregion

        #region Animator Jump
        if(jumpTimer == 0)
        {
           animator.SetFloat("Jump", -1);
        }
        else
        {
           animator.SetFloat("Jump", 1);
        }
        
        #endregion 

    }

    #region utility_functions
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "border"){
            Debug.Log("hit");
            direction = !direction;
        }

        if (col.gameObject.tag == "obstacle")
        {
            Debug.Log("hit");
            direction = !direction;
        }

        collisionCount = 1;

        if (col.gameObject.tag == "Ocean")
        {
            Destroy(this.gameObject);
            gremlinDead += 1;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        collisionCount = 0;
    }

    void gremlin_Ability(Vector2 pos) {
        if (gremlin_type == "Digger")
        {
            if (Input.GetKeyDown(KeyCode.Space) && is_Clicked)
            {
                isDigging = true;
                pos.y -= speed * Time.deltaTime;
                Debug.Log("Digging");
                CountOfDiggs += 1;
            }
            diggingTimer -= Time.deltaTime;
        }

        else if (gremlin_type == "Jumper")
        {
            Debug.Log(jumpTimer);
            if (Input.GetKeyDown(KeyCode.Space) && jumpTimer == 0 && is_Clicked)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpTimer = 1;
            }
            jumpTimer = Math.Max(jumpTimer - Time.deltaTime, 0);
        }

        else if (gremlin_type == "Stone")
        {
            Debug.Log("stoneTimer");
            if (Input.GetKeyDown(KeyCode.Space) && is_Clicked)
            {
                if (direction == true)
                {
                    Instantiate(stoneGenerated, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    gremlinDead += 1;
                }

                else if (direction == false)
                {
                    Instantiate(stoneGeneratedReverse, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    gremlinDead += 1;
                }
            }
        }
    }
    #endregion
}