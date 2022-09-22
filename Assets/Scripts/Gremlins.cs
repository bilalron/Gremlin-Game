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
    
    private string[] gremlins = new string[]{"Default", "Digger", "Jumper"};

    private float jumpTimer = 0;

    static public bool isDigging = false;

    private float diggingTimer = 2;

    public float horizontalVelocity; 

    public Animator animator;
    
    public bool is_Clicked = false;

    private float click_Timer = 0;

    #endregion

    void OnMouseDown() {
        if(click_Timer == 0) {
            Debug.Log("Click");
            is_Clicked = true;
            click_Timer = 3;
        }
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
        click_Timer = Math.Max(0, click_Timer - Time.deltaTime);

        if (click_Timer == 0) {
            is_Clicked = false;
        }



        StartCoroutine(CalculateHorizontalVelocity());

        Vector2 pos1 = transform.position;
        
        gremlin_Ability(pos1);
        

        diggingTimer = Math.Max(0, diggingTimer - Time.deltaTime);

        if(diggingTimer == 0) {
            isDigging = false;
            diggingTimer = 2;
        }

        if (direction)
        {
            pos1.x += speed * Time.deltaTime;
        }
        else
        {
            pos1.x -= speed * Time.deltaTime;
        }
        


        int index;

        if (Input.GetKeyDown(KeyCode.E)) {
            index = Array.IndexOf(gremlins, gremlin_type);
            if (index == gremlins.Length - 1) {
                gremlin_type = gremlins[0];
            }
            else {
                gremlin_type = gremlins[index + 1];
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            index = Array.IndexOf(gremlins, gremlin_type);
            if (index == 0) {
                gremlin_type = gremlins[gremlins.Length - 1];
            }
            else {
                gremlin_type = gremlins[index - 1];
            }
        }

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

    }


    #region utility_functions
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "border"){

            direction = !direction;
        }

        if (col.gameObject.tag == "obstacle")
        {
            direction = !direction;
        }

    }
    
    void gremlin_Ability(Vector2 pos){
        if(gremlin_type == "Digger") {
            if(Input.GetKeyDown(KeyCode.Space) && is_Clicked) {
                isDigging = true;
                pos.y -= speed * Time.deltaTime;
                Debug.Log("Digging");
            }
            diggingTimer -= Time.deltaTime;
        }

        else if (gremlin_type == "Jumper"){
            if (Input.GetKeyDown(KeyCode.Space) && jumpTimer == 0 && is_Clicked){
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpTimer = 1;
            }
            jumpTimer = Math.Max(jumpTimer - Time.deltaTime, 0);
        }
    }

    #endregion
}