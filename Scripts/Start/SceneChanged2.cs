using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanged2 : MonoBehaviour
{
    public GameObject go;
    public Transform village;
    public Text text;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneGoTo.LoadScene("Weather", text, village, go);
        }
    }
}
