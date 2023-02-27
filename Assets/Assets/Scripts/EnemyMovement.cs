using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navAgent; 


    //uses a navmesh to allow the enemy to move around and follow the player
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    //This function makes the enemy find and follow the player
    void Update()
    {
        navAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
