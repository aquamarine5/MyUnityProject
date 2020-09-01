using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        if (Screen.width == 1920)
        {
            canvas.scaleFactor = 1.5f;
        }
        else if (Screen.width == 1080)
        {
            canvas.scaleFactor = 1f;
        }
    }
}
