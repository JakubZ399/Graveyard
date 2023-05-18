using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;
    public float enemyAttackRange = 1f;
    public float enemyAttackSpeed = 2f;
    
    public bool corutineStarted;
    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, EnemyPathfinding.playerObj.transform.position);
        if (distance < enemyAttackRange && corutineStarted == false)
        {
            StartCoroutine(AttackOverTime());
        }
    }

    private IEnumerator AttackOverTime()
    {
        corutineStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(enemyAttackSpeed);
            HealthSystem.currentPlayerHealthStatic -= enemyDamage;
        }
    }
}
