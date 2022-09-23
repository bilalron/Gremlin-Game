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

    [SerializeField]
    private GameObject SpawnPoint;

    [SerializeField]
    private bool SpawnAllowance = true;

    [SerializeField]
    public static float DiggerDeCounter;


    // Start is called before the first frame update
    void Start()
    {
        DiggerDeCounter = diggerCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogBox.StartSpawning && SpawnAllowance)
        {
            StartCoroutine(spawnPlayer(diggerInterval, diggerGremlin));
            SpawnAllowance = false;
        }
    }

    private IEnumerator spawnPlayer(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlayer = Instantiate(player, SpawnPoint.transform.position, Quaternion.identity);
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
