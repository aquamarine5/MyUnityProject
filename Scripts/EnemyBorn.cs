using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    public new GameObject gameObject;
    public float borntime = 5f;
    public Transform bornTransform;
    void Start()
    {
        InvokeRepeating("Born", borntime, borntime);
    }

    // Update is called once per frame
     public void Born()
    {
        Instantiate(gameObject, bornTransform.position, bornTransform.rotation);
    }
}
