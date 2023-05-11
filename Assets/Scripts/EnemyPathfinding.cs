using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private Vector3 playerPos;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //set destination to player
        playerPos = playerObj.transform.position;
        navMeshAgent.SetDestination(playerPos);       
    }
}
