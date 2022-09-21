using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerJumper : MonoBehaviour
{
    [SerializeField]
    private GameObject jumperGremlin;

    [SerializeField]
    public float jumperInterval;

    [SerializeField]
    public float jumperCounter;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPlayer(jumperInterval, jumperGremlin));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnPlayer(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlayer = Instantiate(player, transform.position, Quaternion.identity);
        jumperCounter -= 1;

        if (jumperCounter == 0)
        {
            StopCoroutine(spawnPlayer(interval, player));
        }
        else
        {
            StartCoroutine(spawnPlayer(interval, player));
        }
    }
}
