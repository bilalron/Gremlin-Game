using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{

    #region Important Variables

    [SerializeField]
    public GameObject gremlinBox;

    [SerializeField]
    public GameObject gremlinBox2;

    [SerializeField]
    public GameObject gremlinBox3;

    [SerializeField]
    public GameObject boxPoint;

    [SerializeField]
    public int BoxCounter = 0;

    [SerializeField]
    public static bool StartSpawning = false;



    #endregion 

    void Awake()
    {
        Debug.Log("Instantiate gremlin");
        Instantiate(gremlinBox, boxPoint.transform.position, Quaternion.identity);
    }

    void Update()
    {
        Debug.Log("Hi");
        if (Input.anyKeyDown)
        {
            if (BoxCounter == 0)
            {
                Destroy(GameObject.FindWithTag("GremlinBox"));
                Instantiate(gremlinBox2, boxPoint.transform.position, Quaternion.identity);
                BoxCounter = 1;
            }

            else if (BoxCounter == 1)
            {
                Destroy(GameObject.FindWithTag("GremlinBox"));
                Instantiate(gremlinBox3, boxPoint.transform.position, Quaternion.identity);
                BoxCounter = 2;
            }

            else if (BoxCounter == 2)
            {
                Debug.Log("TestBox3");
                Destroy(GameObject.FindWithTag("GremlinBox"));
                StartSpawning = true;
            }
        }
    }
}
