using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    public Button bt1;
    public Button bt2;
    public Button bt3;
    public Button btexp;
    
    public void OnButton1()
    {
        return;
    }
    public void OnButton2()
    {
        PlayerPrefs.SetInt("shl", PlayerPrefs.GetInt("shl") - 5);
        switch (Random.Range(0,8))
        {
            case 0:
                {
                    PlayerPrefs.SetInt("blg", PlayerPrefs.GetInt("blg")+1);
                    break;
                }
            case 1:
                {
                    PlayerPrefs.SetInt("dsy", PlayerPrefs.GetInt("dsy")+1);
                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetInt("jyh", PlayerPrefs.GetInt("jyh")+1);
                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetInt("mmd", PlayerPrefs.GetInt("mmd")+1);
                    break;
                }
            case 4:
                {
                    PlayerPrefs.SetInt("pgy", PlayerPrefs.GetInt("pgy")+1);
                    break;
                }
            case 5:
                {
                    PlayerPrefs.SetInt("sgc", PlayerPrefs.GetInt("sgc")+1);
                    break;
                }
            case 6:
                {
                    PlayerPrefs.SetInt("shs", PlayerPrefs.GetInt("shs")+1);
                    break;
                }
            case 7:
                {
                    PlayerPrefs.SetInt("xds", PlayerPrefs.GetInt("xds")+1);
                    break;
                }
            case 8:
                {
                    PlayerPrefs.SetInt("shl", PlayerPrefs.GetInt("shl")+1);
                    break;
                }
        }
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("shl") >= 5)
        {
            bt2.interactable = true;
        }
        else
        {
            bt2.interactable = false;
        }
        if (PlayerPrefs.GetInt("qdDays") != DateTime.Now.DayOfYear)
        {
            bt3.interactable = true;
        }
        else
        {
            bt3.interactable = false;
        }
        if (PlayerPrefs.GetInt("score") >= 2000)
        {
            btexp.interactable = true;
        }
        else
        {
            btexp.interactable = false;
        }
    }
    public void OnButton3()
    {
        switch (Random.Range(0, 8))
        {
            case 0:
                {
                    PlayerPrefs.SetInt("blg", PlayerPrefs.GetInt("blg") + 1);
                    break;
                }
            case 1:
                {
                    PlayerPrefs.SetInt("dsy", PlayerPrefs.GetInt("dsy") + 1);
                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetInt("jyh", PlayerPrefs.GetInt("jyh") + 1);
                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetInt("mmd", PlayerPrefs.GetInt("mmd") + 1);
                    break;
                }
            case 4:
                {
                    PlayerPrefs.SetInt("pgy", PlayerPrefs.GetInt("pgy") + 1);
                    break;
                }
            case 5:
                {
                    PlayerPrefs.SetInt("sgc", PlayerPrefs.GetInt("sgc") + 1);
                    break;
                }
            case 6:
                {
                    PlayerPrefs.SetInt("shs", PlayerPrefs.GetInt("shs") + 1);
                    break;
                }
            case 7:
                {
                    PlayerPrefs.SetInt("xds", PlayerPrefs.GetInt("xds") + 1);
                    break;
                }
            case 8:
                {
                    PlayerPrefs.SetInt("shl", PlayerPrefs.GetInt("shl") + 1);
                    break;
                }
        }
        PlayerPrefs.SetInt("qdDays", DateTime.Now.DayOfYear);
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("shl") >= 5)
        {
            bt2.interactable = true;
        }
        else
        {
            bt2.interactable = false;
        }
        if (PlayerPrefs.GetInt("qdDays") != DateTime.Now.DayOfYear)
        {
            bt3.interactable = true;
        }
        else
        {
            bt3.interactable = false;
        }
        if (PlayerPrefs.GetInt("score") >= 2000)
        {
            btexp.interactable = true;
        }
        else
        {
            btexp.interactable = false;
        }
    }
    public void OnButtonExp()
    {
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 2000);
        switch (Random.Range(0, 8))
        {
            case 0:
                {
                    PlayerPrefs.SetInt("blg", PlayerPrefs.GetInt("blg") + 1);
                    break;
                }
            case 1:
                {
                    PlayerPrefs.SetInt("dsy", PlayerPrefs.GetInt("dsy") + 1);
                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetInt("jyh", PlayerPrefs.GetInt("jyh") + 1);
                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetInt("mmd", PlayerPrefs.GetInt("mmd") + 1);
                    break;
                }
            case 4:
                {
                    PlayerPrefs.SetInt("pgy", PlayerPrefs.GetInt("pgy") + 1);
                    break;
                }
            case 5:
                {
                    PlayerPrefs.SetInt("sgc", PlayerPrefs.GetInt("sgc") + 1);
                    break;
                }
            case 6:
                {
                    PlayerPrefs.SetInt("shs", PlayerPrefs.GetInt("shs") + 1);
                    break;
                }
            case 7:
                {
                    PlayerPrefs.SetInt("xds", PlayerPrefs.GetInt("xds") + 1);
                    break;
                }
            case 8:
                {
                    PlayerPrefs.SetInt("shl", PlayerPrefs.GetInt("shl") + 1);
                    break;
                }
        }
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("shl") >= 5)
        {
            bt2.interactable = true;
        }
        else
        {
            bt2.interactable = false;
        }
        if (PlayerPrefs.GetInt("qdDays") != DateTime.Now.DayOfYear)
        {
            bt3.interactable = true;
        }
        else
        {
            bt3.interactable = false;
        }
        if (PlayerPrefs.GetInt("score") >= 2000)
        {
            btexp.interactable = true;
        }
        else
        {
            btexp.interactable = false;
        }
    }
}
