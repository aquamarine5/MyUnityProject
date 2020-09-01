using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHLData : MonoBehaviour
{
    public Text text;
    private void Update()
    {
        text.text = PlayerPrefs.GetInt("shl").ToString();
    }
}
