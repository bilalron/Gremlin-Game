using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScreen : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
