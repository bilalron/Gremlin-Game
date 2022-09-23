using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Obstacle : MonoBehaviour
{
    public float objectDigging;

    public float diggingTime;

    private float TimeTrack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Gremlins.isDigging == true)
        {
            objectDigging = 1;
        }

        if (Gremlins.isDigging == false)
        {
            objectDigging = 0;
        }
    }

    #region Destruction Function
    void OnTriggerStay2D(Collider2D cother)
    {
        if (cother.gameObject.tag == "DiggerGremlin" && objectDigging == 1)
        {
            Debug.Log("DiggingObject");
            Destroy(this.gameObject);
        }
    }
    #endregion
}
