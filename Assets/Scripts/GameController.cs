using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ 
    public static GameController Instance = null;

    #region Important Variables

    [SerializeField]
    public GameObject UIBoard;

    [SerializeField]
    public GameObject uiboardPoint;

    [SerializeField]
    public int UIBoardCounter = 0;

    #endregion


    #region Unity_functions

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else if (Instance != this){
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Scene_transitions

    public void StartGame(){
        Gremlins.gremlinDead = 0;
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

    public void HowToPlay()
    {
        if (UIBoardCounter == 0)
        {
            Instantiate(UIBoard, uiboardPoint.transform.position, Quaternion.identity);
            UIBoardCounter = 1;
        }

        else if (UIBoardCounter == 1)
        {
            Destroy(GameObject.FindWithTag("UIBoard"));
            UIBoardCounter = 0;
        }
    }

    public void PauseScreen()
    {
        SceneManager.LoadScene("PauseMenu");
    }
    public void EndApplication()
    {
        Application.Quit();
    }

    #endregion
}
