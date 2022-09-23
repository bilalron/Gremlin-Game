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

    [SerializeField]
    private GameObject SpawnPoint;

    [SerializeField]
    private bool SpawnAllowance = true;

    [SerializeField]
    public static float JumperDeCounter;

    // Start is called before the first frame update
    void Start()
    {
        JumperDeCounter = jumperCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogBox.StartSpawning && SpawnAllowance)
        {
            StartCoroutine(spawnPlayer(jumperInterval, jumperGremlin));
            SpawnAllowance = false;
        }
    }

    private IEnumerator spawnPlayer(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlayer = Instantiate(player, SpawnPoint.transform.position, Quaternion.identity);
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
