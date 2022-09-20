using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ 
    public static GameController Instance = null;

    #region Unity_functions

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else if (Instance != this){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    #region Scene_transitions

    public void StartGame(){
        SceneManager.LoadScene("MainMenu");
    }
     public void LoseGame(){
        SceneManager.LoadScene("LoseScene");
    }
     public void WinGame(){
        SceneManager.LoadScene("WinScene");
    }
     public void StartScreen(){
        SceneManager.LoadScene("StartScreen"); 
    }

    #endregion
}
