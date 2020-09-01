using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemyBorn : MonoBehaviour
{
    public bool isHellephant = false;
    public new GameObject gameObject;
    public GameObject superEnemyParticle;
    public GameObject superZCY;
    public Sprite[] sprites;
    public Sprite Nothing;
    public float borntime = 5f;
    public Transform bornTransform;
    int rangeSeed;
    GameObject bornEnemy;
    void Start()
    {
        InvokeRepeating("Born", borntime, borntime);
    }

    public void Born()
    {
        bornTransform.position = new Vector3(Random.Range(-1f, -49f), 0, Random.Range(-1f, -49f));
        bornTransform.rotation = new Quaternion(0, Random.Range(1, 359), 0, 0);

        if (Random.Range(0, 10) == 5)
        {
            bornEnemy=Instantiate(gameObject, bornTransform.position, bornTransform.rotation);
            bornEnemy.transform.localScale = new Vector3(3, 3, 3);
            if (isHellephant) 
            {
                bornEnemy.GetComponent<SuperEnemyHealth>().enemyMaxHealth = 120;
                bornEnemy.GetComponent<EnemyAttack>().attackHp = 60;
                bornEnemy.GetComponent<SuperEnemyHealth>().killScore = 50;
            }
            else
            {
                bornEnemy.GetComponent<SuperEnemyHealth>().enemyMaxHealth = 50;
                bornEnemy.GetComponent<EnemyAttack>().attackHp = 30;
                bornEnemy.GetComponent<SuperEnemyHealth>().killScore = 30;
            }
            Instantiate(superEnemyParticle, bornEnemy.transform);
            rangeSeed = 50;
        }
        else
        {
            bornEnemy = Instantiate(gameObject, bornTransform.position, bornTransform.rotation);
            rangeSeed = 100;
        }
        switch (Random.Range(1,rangeSeed))
        {
            case 2:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 0;
                    break;
                }
            case 3:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 1;
                    break;
                }
            case 4:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[2];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 2;
                    break;
                }
            case 5:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[3];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 3;
                    break;
                }
            case 6:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[4];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 4;
                    break;
                }
            case 7:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[5];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 5;
                    break;
                }
            case 8:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[6];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 6;
                    break;
                }
            case 9:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[7];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 7;
                    break;
                }
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = sprites[8];
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = 8;
                    break;
                }
            default:
                {
                    bornEnemy.GetComponentInChildren<SpriteRenderer>().sprite = Nothing;
                    bornEnemy.GetComponentInChildren<SuperEnemyHealth>().spriteIndex = -1;
                    break;
                }
        }
    }
}
