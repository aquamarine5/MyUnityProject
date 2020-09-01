using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Geography_Main : MonoBehaviour
{
    public Text text1;
    public Text text2;
    float time;
    bool showing = false;
    private void Update()
    {
        if (showing)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                text1.enabled = false;
                text2.enabled = false;
                showing = false;
                time = 0;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SD")
        {
            text1.enabled = true;
            text2.enabled = true;
            text1.text = "达成成就：山顶！";
            text2.text = "这也不高啊";
            showing = true;
        }
        if (other.tag == "AB")
        {
            text1.enabled = true;
            text2.enabled = true;
            text1.text = "达成成就：鞍部~";
            text2.text = "这附近也没马啊";
            showing = true;
        }
        if (other.tag == "SG")
        {
            text1.enabled = true;
            text2.enabled = true;
            text1.text = "达成成就：山谷";
            text2.text = "没河啊";
            showing = true;
        }
        if (other.tag == "SJ")
        {
            text1.enabled = true;
            text2.enabled = true;
            text1.text = "达成成就：山脊！";
            text2.text = "诶嘿有鸡";
            showing = true;
        }
        if (other.tag == "DY")
        {
            text1.enabled = true;
            text2.enabled = true;
            text1.text = "达成成就：陡崖！";
            text2.text = "";
            showing = true;
        }
    }
}
