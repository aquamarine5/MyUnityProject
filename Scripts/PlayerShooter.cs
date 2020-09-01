using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    new ParticleSystem particleSystem;
    LineRenderer lineRenderer;
    public new Light light;
    bool buttonClick = false;
    float shootTimer;
    Ray shootRay;
    int shootMask;
    public int shootLength = 100;
    public float shootCD = 0.15f;
    public int killhp = 10;
    public AudioSource playerShoot;
    public GameObject player;
    void Start()
    {
        particleSystem = player.GetComponent<ParticleSystem>();
        lineRenderer = player.GetComponent<LineRenderer>();
        shootMask = LayerMask.GetMask("Shootable");
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (buttonClick && shootTimer >= shootCD)
        {
            Shoot();
        }
        else if(shootTimer>=shootCD)
        {
            shootTimer = 0;
            lineRenderer.enabled = false;
            light.enabled = false;
        }
    }
    void Shoot()
    {
        playerShoot.Play();
        light.enabled = true;
        buttonClick = false;
        shootTimer = 0;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, player.transform.position);
        particleSystem.Stop();
        particleSystem.Play();
        shootRay.origin = player.transform.position;
        shootRay.direction = player.transform.forward;
        if(Physics.Raycast(shootRay,out RaycastHit raycastHit, shootLength, shootMask))
        {
            SuperEnemyHealth enemyHealth = raycastHit.collider.GetComponent<SuperEnemyHealth>();
            if (enemyHealth == null)
            {
                if (raycastHit.collider.GetComponent<EnemyHealth>() != null)
                {
                    raycastHit.collider.GetComponent<EnemyHealth>().KillHealth(10);
                }
            }
            else
            {
                enemyHealth.KillHealth(10);
            }
            lineRenderer.SetPosition(1, raycastHit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * shootLength);
        }
        
    }
    public void OnButtonClick()
    {
        buttonClick = true;
    }
}
