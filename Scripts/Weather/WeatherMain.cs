using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMain : MonoBehaviour
{
    public X_LB_LightningSource thunder;
    public Transform player;
    public Transform floorTransform;
    float timer=0f;
    float random;
    float thunderX;
    float thunderY;
    void Update()
    {
        timer += Time.deltaTime;
        random = Random.Range(0.1f, 3f);
        if (random * timer >= 6f)
        {
            timer = 0;
            ThunderPlay();
        }
    }
    void ThunderPlay()
    {
        thunderX = Random.Range(player.position.x - 15f, player.position.x + 15f);
        thunderY = Random.Range(player.position.z - 15f, player.position.z + 15f);
        thunder.gameObject.transform.position = new Vector3(thunderX, 50, thunderY);
        floorTransform.position = new Vector3(thunderX, -27, thunderY);
        thunder.StrikeOnce();
        
    }
    
}
