using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject dieUI;
    public Transform cameraTransform;
    public Transform playerTransform;
    public bool isStart;
    public Text text;
    public Transform village;
    public GameObject gos;
    public void RestartClick()
    {
        SceneManager.LoadScene("Start");
    }
}
