using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text text;
    public GameObject gameobject;
    public Transform village;
    bool isPause = false;
    public GameObject pauseUI;
    public void OnButtonClick()
    {
        if (isPause) { pauseUI.SetActive(false);
            Time.timeScale = 1; 
        }
        else { pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        isPause = !isPause;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GoToScene()
    {
        Time.timeScale = 1;
        SceneGoTo.LoadScene("Start", text, village, gameobject);
    }

}
