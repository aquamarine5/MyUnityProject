using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public GameObject ui;
    public GameObject bookUI;
    bool isOpen;
    private void OnTriggerEnter(Collider other)
    {
        ui.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
    public void OnButtonClick()
    {
        if (isOpen)
        {
            bookUI.SetActive(false);
            Time.timeScale = 1;
            isOpen = false;
        }
        else
        {
            bookUI.SetActive(true);
            Time.timeScale = 0;
            isOpen = true;
        }
    }
}
