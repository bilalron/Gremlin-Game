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

        TimeTrack -= Time.deltaTime;

        if (TimeTrack > diggingTime)
        {
            objectDigging = 0;
        }
    }

    #region Destruction Function
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "DiggerGremlin" && objectDigging == 1)
        {
            Debug.Log("DiggingObject");
            Destroy(this.gameObject);
        }
    }
    #endregion
}
