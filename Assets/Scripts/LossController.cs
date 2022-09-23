using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LossController : MonoBehaviour
{
    [SerializeField]
    public static float GremlinsAlive;

    public Text GremlinsWhoLive;

    private float Countdown = 5;

    void Start()
    {

    }


    void Update()
    {
        Countdown = Math.Max(0, Countdown - Time.deltaTime);

        if (Countdown == 0 && DialogBox.StartSpawning)
        {
            GremlinsAlive = SpawnControllerJumper.JumperDeCounter + SpawnControllerDigger.DiggerDeCounter + StonerSpawnController.StonerDeCounter - Gremlins.gremlinDead;

            if (WinController.GremlinsToWinCounter > GremlinsAlive)
            {
                Gremlins.gremlinDead = 0;
                SceneManager.LoadScene("LoseScene_1");
            }

            GremlinsWhoLive.text = GremlinsAlive.ToString();
        }
    }
}
