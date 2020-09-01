using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperEnemyHealth : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public bool isDead = false;
    public SpriteRenderer rendererSprite;
    public int killScore;
    public int spriteIndex=-1;
    int enemyHealth;
    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    public void KillHealth(int attackHp)
    {
        enemyHealth -= attackHp;
        if (enemyHealth <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetBool("isDeath", isDead);
            
        }
    }
    public void StartSinking()
    {
        Destroy(gameObject,2f);
        Score.localScore += killScore * Effect.ScoreUp;
        PlayerZCY.Zcy(rendererSprite.sprite);
        switch (spriteIndex)
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
            case -1:
                {
                    break;
                }
        }
        PlayerPrefs.Save();
    }
}
