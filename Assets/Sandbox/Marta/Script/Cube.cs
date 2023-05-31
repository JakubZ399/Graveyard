using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private EnemyPathfinding _enemyPathfinding;
    private EnemyAttack _enemyAttack;
    public int health = 50;

    private Animator _animator;

    public GameObject medicine;

    private void Start()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyPathfinding = GetComponent<EnemyPathfinding>();
        
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathAnimation();
        }
    }

    private void DeathAnimation()
    {
        _enemyAttack.enabled = false;
        _enemyPathfinding.enabled = false;

        _animator.SetBool("isDeath", true);
        Destroy(gameObject, 15f);

        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

}
