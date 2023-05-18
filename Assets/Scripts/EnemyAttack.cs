using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;
    public int enemyAttackRange = 1;
    public int enemyAttackSpeed = 1;

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, EnemyPathfinding.playerObj.transform.position);
        if (distance < 1)
        {
            HealthSystem.currentPlayerHealthStatic =- enemyDamage;
        }
    }
}
