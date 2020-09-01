using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public AudioSource campfireSource;
    public AudioClip[] fireHurtClips;
    public AudioClip[] campfireClips;
    float fireTimer = 0f;
    float timer = 0f;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            fireTimer += Time.deltaTime;
            if (fireTimer >= 0.5)
            {
                fireTimer = 0f;
                campfireSource.clip = fireHurtClips[Random.Range(0, 3)];
                campfireSource.Play();
                playerHealth.KillHealth(5, false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RenderSettings.fogDensity = 0.11f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RenderSettings.fogDensity = 0.15f;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            campfireSource.clip = campfireClips[Random.Range(0, 6)];
            campfireSource.Play();
            timer = 0;
        }
    }
}
