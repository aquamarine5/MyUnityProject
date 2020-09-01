using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    public PlayerJump playerJump;
    public void OnButtonClick()
    {
        playerJump.OnButtonClick();
    }
}
