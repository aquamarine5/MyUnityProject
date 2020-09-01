using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Geography_AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(new Vector3(player.transform.position.x,player.transform.position.z,1));
    }
}
