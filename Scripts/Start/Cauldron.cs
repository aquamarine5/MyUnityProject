using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public Image[] images;
    public Sprite[] Gs;
    public Sprite[] Hs;
    public Text[] Texts;
    public GameObject zcyUI;
    public GameObject zcyButton;
    public Button cookButton;
    public Renderer rendererCauldron;
    public Material[] materials;
    public Village v1;
    public Village v2;
    public Village v3;
    public GameObject go;
    public AudioSource audioSource;
    int has;
    int save=0;
    int has2;
    bool isOpen=false;
    private void Awake()
    {
        save = PlayerPrefs.GetInt("mzdc");
        if (save >= 3)
        {
            save = 0;
            PlayerPrefs.SetInt("mzdc", 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        zcyButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        zcyButton.SetActive(false);
    }
    public void OnButtonCook()
    {
        PlayerPrefs.SetInt("blg", PlayerPrefs.GetInt("blg") - 1);
        PlayerPrefs.SetInt("dsy", PlayerPrefs.GetInt("dsy") - 1);
        PlayerPrefs.SetInt("jyh", PlayerPrefs.GetInt("jyh") - 1);
        PlayerPrefs.SetInt("mmd", PlayerPrefs.GetInt("mmd") - 1);
        PlayerPrefs.SetInt("pgy", PlayerPrefs.GetInt("pgy") - 1);
        PlayerPrefs.SetInt("sgc", PlayerPrefs.GetInt("shgc") - 1);
        PlayerPrefs.SetInt("shs", PlayerPrefs.GetInt("shs") - 1);
        PlayerPrefs.SetInt("xds", PlayerPrefs.GetInt("xds") - 1);
        PlayerPrefs.SetInt("mzdc", PlayerPrefs.GetInt("mzdc") + 1);
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("blg") == 0)
        {
            images[0].sprite = Gs[0];
        }
        else
        {
            Texts[0].text = PlayerPrefs.GetInt("blg").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("dsy") == 0)
        {
            images[1].sprite = Gs[1];
        }
        else
        {
            Texts[1].text = PlayerPrefs.GetInt("dsy").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("jyh") == 0)
        {
            images[2].sprite = Gs[2];
        }
        else
        {
            Texts[2].text = PlayerPrefs.GetInt("jyh").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("mmd") == 0)
        {
            images[3].sprite = Gs[3];
        }
        else
        {
            Texts[3].text = PlayerPrefs.GetInt("mmd").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("pgy") == 0)
        {
            images[4].sprite = Gs[4];
        }
        else
        {
            Texts[4].text = PlayerPrefs.GetInt("pgy").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("sgc") == 0)
        {
            images[5].sprite = Gs[5];
        }
        else
        {
            Texts[5].text = PlayerPrefs.GetInt("sgc").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("shs") == 0)
        {
            images[6].sprite = Gs[6];
        }
        else
        {
            Texts[6].text = PlayerPrefs.GetInt("shs").ToString();
            has2 += 1;
        }
        if (PlayerPrefs.GetInt("xds") == 0)
        {
            images[7].sprite = Gs[7];
        }
        else
        {
            Texts[7].text = PlayerPrefs.GetInt("xds").ToString();
            has2 += 1;
        }
        
        switch (save)
        {
            case 0:
                v1.Save();
                save = 1;
                PlayerPrefs.SetInt("mzdc", 1);
                PlayerPrefs.Save();
                break;
            case 1:
                v2.Save();
                save = 2;
                PlayerPrefs.SetInt("mzdc", 2);
                PlayerPrefs.Save();
                break;
            case 2:
                v3.Save();
                go.SetActive(true);
                PlayerPrefs.SetInt("mzdc", 3);
                PlayerPrefs.Save();
                break;
        }
        if (has2 == 8)
        {
            cookButton.interactable = true;
        }
        else
        {
            cookButton.interactable = false;
        }
        audioSource.Play();
    }
    public void OnButtonClick()
    {
        if (isOpen)
        {
            zcyUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            zcyUI.SetActive(true);
            Time.timeScale = 0;
        }
        isOpen = !isOpen;
        if (PlayerPrefs.GetInt("blg") > 0) { 
            has += 1;
            images[0].sprite = Hs[0];
            Texts[0].text = PlayerPrefs.GetInt("blg").ToString();
        }
        if (PlayerPrefs.GetInt("dsy") > 0) { 
            has += 1;
            images[1].sprite = Hs[1];
            Texts[1].text = PlayerPrefs.GetInt("dsy").ToString();
        }
        if (PlayerPrefs.GetInt("jyh") > 0) { 
            has += 1;
            images[2].sprite = Hs[2];
            Texts[2].text = PlayerPrefs.GetInt("jyh").ToString();
        }
        if (PlayerPrefs.GetInt("mmd") > 0) { 
            has += 1;
            images[3].sprite = Hs[3];
            Texts[3].text = PlayerPrefs.GetInt("mmd").ToString();
        }
        if (PlayerPrefs.GetInt("pgy") > 0) {
            has += 1;
            images[4].sprite = Hs[4];
            Texts[4].text = PlayerPrefs.GetInt("pgy").ToString();
        }
        if (PlayerPrefs.GetInt("sgc") > 0) {
            has += 1;
            images[5].sprite = Hs[5];
            Texts[5].text = PlayerPrefs.GetInt("sgc").ToString();
        }
        if (PlayerPrefs.GetInt("shs") > 0) { 
            has += 1;
            images[6].sprite = Hs[6];
            Texts[6].text = PlayerPrefs.GetInt("shs").ToString();
        }
        if (PlayerPrefs.GetInt("xds") > 0) {
            has += 1;
            images[7].sprite = Hs[7];
            Texts[7].text = PlayerPrefs.GetInt("xds").ToString();
        }
        if (has == 0)
        {
            cookButton.interactable = false;
            rendererCauldron.material = materials[0];
        }
        else if (has > 0&& has < 5)
        {
            cookButton.interactable = false;
            rendererCauldron.material = materials[1];
        }
        else if (has == 8)
        {
            cookButton.interactable = true;
            rendererCauldron.material = materials[2];
        }
        else
        {
            cookButton.interactable = false;
            rendererCauldron.material = materials[2];
        }
        has = 0;
    }
}
