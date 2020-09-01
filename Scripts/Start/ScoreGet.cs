using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGet : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = PlayerPrefs.GetInt("score").ToString();
    }
}
