using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qd : MonoBehaviour
{
    public void OnButtonClick()
    {
        if (PlayerPrefs.GetInt("qdDays") == DateTime.Now.Day)
        {
            Debug.Log(1);
        }
    }
}
