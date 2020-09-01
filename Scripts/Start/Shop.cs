using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject ui;
    public GameObject bookUI;
    bool isOpen;
    public Button bt2;
    public Button bt3;
    public Button bt4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui.SetActive(false);
        }
    }
    public void OnButtonClick()
    {
        if (isOpen)
        {
            bookUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            bookUI.SetActive(true);
            Time.timeScale = 0;
        }
        isOpen = !isOpen;
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
            bt4.interactable = true;
        }
        else
        {
            bt4.interactable = false;
        }
    }
}
