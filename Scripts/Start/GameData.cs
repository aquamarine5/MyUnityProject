using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject self;
    bool isFirst = false;
    void Start()
    {
        if (!isFirst)
        {
            DontDestroyOnLoad(self);
            isFirst = true;
        }
        if (!PlayerPrefs.HasKey("isFirstInstall"))
        {
            PlayerPrefs.SetInt("isFirstInstall", 1);
            PlayerPrefs.SetInt("blg", 0);
            PlayerPrefs.SetInt("dsy", 0);
            PlayerPrefs.SetInt("jyh", 0);
            PlayerPrefs.SetInt("mmd", 0);
            PlayerPrefs.SetInt("pgy", 0);
            PlayerPrefs.SetInt("sgc", 0);
            PlayerPrefs.SetInt("shs", 0);
            PlayerPrefs.SetInt("xds", 0);
            PlayerPrefs.SetInt("mzdc", 0);
            PlayerPrefs.SetInt("shl", 0);
            PlayerPrefs.SetInt("gun_type", 0);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("qdDays", 0);
            PlayerPrefs.Save();
        }
    }
}
