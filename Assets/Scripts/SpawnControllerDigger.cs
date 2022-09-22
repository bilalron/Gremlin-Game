using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerDigger : MonoBehaviour
{

    [SerializeField]
    private GameObject diggerGremlin;

    [SerializeField]
    public float diggerInterval;

    [SerializeField]
    public float diggerCounter;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPlayer(diggerInterval, diggerGremlin));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnPlayer(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlayer = Instantiate(player, transform.position, Quaternion.identity);
        diggerCounter -= 1;

        if (diggerCounter == 0)
        {
            StopCoroutine(spawnPlayer(interval, player));
        }
        else
        {
            StartCoroutine(spawnPlayer(interval, player));
        }
    }
}
