using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaMove : MonoBehaviour
{
    public Transform trans;
    public float speed = 20f;
    Vector3 vector3;
    void Start()
    {
        vector3 = transform.position - trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera = trans.position + vector3;
        transform.position = Vector3.Lerp(transform.position, camera, Time.deltaTime * speed);
    }
}
