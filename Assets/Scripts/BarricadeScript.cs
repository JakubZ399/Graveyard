using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
    public GameObject _barricade;
    public GameObject _barricadeMessage;

    private bool isBuild = false;

    private int _barricadeCurrentHP;
    private int _barricadeMaxHP = 10000;
    
    private bool coroutineStarted;

    private void Start()
    {
        _barricade.SetActive(false);
        _barricadeMessage.SetActive(false);
        isBuild = false;
    }

    private void Update()
    {
        if (_barricadeCurrentHP <= 0)
        {
            _barricade.SetActive(false);
            isBuild = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isBuild)
        {
            _barricadeCurrentHP = _barricadeMaxHP;
            _barricade.SetActive(true);
            _barricadeMessage.SetActive(false);
            isBuild = true;
        }
        
        if (other.gameObject.tag == "Cube" && isBuild)
        {
            EnemyAttack _enemyAttack;
            _enemyAttack = other.GetComponent<EnemyAttack>();
            _enemyAttack.StartBarricadeAttack();
            StartCoroutine(BarricadeDamge());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isBuild)
        {
            _barricadeMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _barricadeMessage.SetActive(false);
        if (other.gameObject.tag == "Cube" && !isBuild)
        {
            EnemyAttack _enemyAttack;
            _enemyAttack = other.GetComponent<EnemyAttack>();
            _enemyAttack.StopBarricadeAttack();
            StopCoroutine(BarricadeDamge());
        }
    }

    private IEnumerator BarricadeDamge()
    {
        coroutineStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(EnemyAttack.enemyAttackSpeedStatic);
            _barricadeCurrentHP -= EnemyAttack.enemyDamageStatic;
            Debug.Log(_barricadeCurrentHP);
            coroutineStarted = false;
            yield break;
        }
    }
}
