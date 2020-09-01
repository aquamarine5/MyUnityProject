using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int localScore = 0;
    public Text text;
    private void Update()
    {
        text.text = "score:" + localScore;
    }
}
