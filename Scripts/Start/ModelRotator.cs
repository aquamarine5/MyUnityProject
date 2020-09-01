using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ModelRotator : MonoBehaviour
{
    public GameObject witch;
    public GameObject player;
    public GameObject wandering_trader;
    public GameObject textMesh;
    public GameObject zombie_piglin;
    void Update()
    {
        witch.transform.rotation=Quaternion.LookRotation(player.transform.position);
        wandering_trader.transform.rotation = Quaternion.LookRotation(player.transform.position);
        zombie_piglin.transform.rotation = Quaternion.LookRotation(player.transform.position);
        textMesh.transform.rotation = Quaternion.LookRotation(player.transform.position);
    }
}
