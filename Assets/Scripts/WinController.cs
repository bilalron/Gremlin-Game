using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public float ScoreCounter;

    public float WinScore;

    public Text GremlinsToWin;

    private float GremlinsToWinCounter;

    void Update()
    {
        if(ScoreCounter == WinScore)
        {
            SceneManager.LoadScene("WinScene");
        }

        GremlinsToWinCounter = WinScore - ScoreCounter;

        GremlinsToWin.text = GremlinsToWinCounter.ToString();
    }

    #region Win Function
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DiggerGremlin")
        {
            Debug.Log("Score");
            ScoreCounter += 1;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "JumperGremlin")
        {
            Debug.Log("Score");
            ScoreCounter += 1;
            Destroy(col.gameObject);
        }

    }

    #endregion 
}
