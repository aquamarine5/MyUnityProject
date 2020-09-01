using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public bool isDead = false;
    public Rigidbody rd;
    bool isSliking;
    public EnemyFollow ef;
    public int killScore;
    int enemyHealth;
    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }
    private void Update()
    {
        if (isSliking)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2f);
        }
    }
    public void KillHealth(int attackHp)
    {
        if (isDead) { return; }
        enemyHealth -= attackHp;
        if (enemyHealth <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetBool("isDeath", isDead);
            ef.enabled = false;
        }
    }
    public void StartSinking()
    {
        isSliking = true;
        rd.isKinematic = true;
        Destroy(gameObject,2f);
        Score.localScore += killScore * Effect.ScoreUp;
        
    }
}
