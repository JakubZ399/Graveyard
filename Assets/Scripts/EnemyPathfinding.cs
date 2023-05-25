using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public static GameObject playerObj;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Vector3 playerPos;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = Random.Range(2.4f, 3.5f);
    }

    private void Update()
    {
        //set destination to player
        playerPos = playerObj.transform.position;
        navMeshAgent.SetDestination(playerPos);       
    }
}
