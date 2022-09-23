using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class InGameController : MonoBehaviour
{
    public static float click_Timer = 0;

    public static InGameController Instance = null;

    #region Unity_functions

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Scene_transitions

    void Update()
    {
        click_Timer = Math.Max(0, click_Timer - Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            SceneManager.LoadScene("PauseMenu");
        }
    }

    public void PauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    #endregion
}
