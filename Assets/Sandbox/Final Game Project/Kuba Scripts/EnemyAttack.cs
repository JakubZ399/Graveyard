using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;
    
    public float enemyAttackRange = 1f;
    public float enemyAttackSpeed = 2f;

    public ZombieData zombieData;
    
    public static int enemyDamageStatic;
    public static float enemyAttackSpeedStatic;
    
    public bool coroutineStarted;

    private Animator animator;

    private void Start()
    {
        enemyDamageStatic = enemyDamage;
        enemyAttackSpeedStatic = enemyAttackSpeed;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, EnemyPathfinding.playerObj.transform.position);
        if (distance < enemyAttackRange && coroutineStarted == false)
        {
            StartPlayerAttack();
        }
        else
        {
            return;
        }
    }

    private void StartPlayerAttack()
    {
        animator.SetBool("isAttacking", true);
        StartCoroutine(AttackPlayerOverTime());
    }
    
    public void StartBarricadeAttack()
    {
        animator.SetBool("isAttackingBarricade", true);
    }
    
    public void StopBarricadeAttack()
    {
        animator.SetBool("isAttackingBarricade", false);
    }

    private IEnumerator AttackPlayerOverTime()
    {
        coroutineStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(enemyAttackSpeed);
            animator.SetBool("isAttacking", false);
            GunShoot._playerCameraStatic.DOShakeRotation(0.2f, 10f, 1, 90f);
            HealthSystem.currentPlayerHealthStatic -= enemyDamage;
            coroutineStarted = false;
            yield break;
        }
    }
}
