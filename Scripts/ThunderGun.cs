using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderGun : MonoBehaviour
{
    public X_LB_LightningSource lightningSource;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            timer = 0;
            lightningSource.StrikeOnce();
        }
    }
}
