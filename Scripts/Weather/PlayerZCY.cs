using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerZCY : MonoBehaviour
{
    public Animator animator;
    public Image image;
    static Animator staticAnimator;
    static Image staticImage;
    private void Start()
    {
        staticAnimator = animator;
        staticImage = image;
    }
    public static void Zcy(Sprite sprite)
    {
        staticImage.sprite = sprite;
        staticAnimator.SetTrigger("Zcy");
    }
}
