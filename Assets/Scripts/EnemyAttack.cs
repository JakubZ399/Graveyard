using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;
    
    public float enemyAttackRange = 1f;
    public float enemyAttackSpeed = 2f;
    
    public bool coroutineStarted;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, EnemyPathfinding.playerObj.transform.position);
        if (distance < enemyAttackRange && coroutineStarted == false)
        {
            animator.SetBool("isAttacking", true);
            StartCoroutine(AttackOverTime());
        }
    }

    private IEnumerator AttackOverTime()
    {
        coroutineStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(enemyAttackSpeed);
            animator.SetBool("isAttacking", false);
            HealthSystem.currentPlayerHealthStatic -= enemyDamage;
        }
    }
}
