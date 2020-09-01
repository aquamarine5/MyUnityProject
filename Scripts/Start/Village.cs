using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject go;
    public void Save()
    {
        go.SetActive(false);
        ps.Play();
    }
}
