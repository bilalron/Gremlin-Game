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

    private bool isDigging = false;

    private float diggingTimer = 2;

    #endregion

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 pos1 = transform.position;

        
        gremlin_Ability(pos1);

        diggingTimer = Math.Max(0, diggingTimer - Time.deltaTime);

        if(diggingTimer == 0) {
            isDigging = false;
            diggingTimer = 2;
        }
        if(!isDigging) { 
            if (direction){
                pos1.x += speed * Time.deltaTime;
            }
            else {
                pos1.x -= speed * Time.deltaTime;
            }
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
    }

    #region utility_functions
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "border"){
            Debug.Log("hit");
            direction = !direction;
        }
    }
    
    void gremlin_Ability(Vector2 pos){
        if(gremlin_type == "Digger") {
            if(Input.GetKeyDown(KeyCode.Space)) {
                isDigging = true;
                pos.y -= speed * Time.deltaTime;
                Debug.Log("Digging");
            }
            diggingTimer -= Time.deltaTime;
        }

        else if (gremlin_type == "Jumper"){
            Debug.Log(jumpTimer);
            if (Input.GetKeyDown(KeyCode.Space) && jumpTimer == 0){
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpTimer = 1;
            }
            jumpTimer = Math.Max(jumpTimer - Time.deltaTime, 0);
        }
    }
    #endregion
}