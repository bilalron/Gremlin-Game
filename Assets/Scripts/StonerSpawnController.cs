using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonerSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject stonerGremlin;

    [SerializeField]
    public float stonerInterval;

    [SerializeField]
    public float stonerCounter;

    [SerializeField]
    private GameObject SpawnPoint;

    [SerializeField]
    private bool SpawnAllowance = true;

    [SerializeField]
    public static float StonerDeCounter;

    // Start is called before the first frame update
    void Start()
    {
        StonerDeCounter = stonerCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogBox.StartSpawning && SpawnAllowance)
        {
            StartCoroutine(spawnPlayer(stonerInterval, stonerGremlin));
            SpawnAllowance = false;
        }
    }

    private IEnumerator spawnPlayer(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlayer = Instantiate(player, SpawnPoint.transform.position, Quaternion.identity);
        stonerCounter -= 1;

        if (stonerCounter == 0)
        {
            StopCoroutine(spawnPlayer(interval, player));
        }
        else
        {
            StartCoroutine(spawnPlayer(interval, player));
        }
    }
}
