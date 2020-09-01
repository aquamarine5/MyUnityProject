using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth=100;
    public Animator animator;
    public Animator playerAnimator;
    public Sprite die;
    public Image image;
    public AudioSource playerSource;
    public AudioClip dieClip;
    public AudioClip[] hurtClip;
    public Text dieText;
    public Text scoreText;
    public GameObject goDieUI;
    int playerHealth;
    float timer;
    public Slider slider;
    void Start()
    {
        playerHealth = playerMaxHealth;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (playerHealth>=playerMaxHealth) 
            {
                return;
            }
            else
            {
                playerHealth += Effect.HpUp;
                slider.value = playerHealth;
            }
            timer = 0;
        }
    }

    public void KillHealth(int attackHp,bool isPlayVoice=true)
    {
        playerHealth -= attackHp;
        slider.value = playerHealth;
        if (playerMaxHealth * 0.2 >= playerHealth)
        {
            animator.SetBool("isWillDeath", true);
        }
        if (playerHealth <= 0)
        {
            image.sprite = die;
            playerSource.clip = dieClip;
            playerSource.Play();
            playerAnimator.SetBool("isDead", true);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + Score.localScore);
            PlayerPrefs.Save();
            dieText.text = scoreText.text;
            goDieUI.SetActive(true);
            Time.timeScale = 0;
        }
        animator.SetTrigger("isAttack");
        if (isPlayVoice)
        {
            playerSource.clip = hurtClip[Random.Range(0,3)];
            playerSource.Play();
        }
    }
}
