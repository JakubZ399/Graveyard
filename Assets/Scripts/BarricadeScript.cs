using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
    public GameObject _barricade;
    public GameObject _barricadeMessage;
    public GameObject[] _barricadePlank;

    private int _barricadeCurrentHP;
    public int _barricadeMaxHP = 40000;
    public float _buildCooldown = 15f;
    
    
    private bool coroutineStarted;
    private bool isBuild = false;

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
            Invoke("IsBuildOff", _buildCooldown);
        }
        if (_barricade.activeSelf && _barricadeCurrentHP <= (_barricadeMaxHP/4)*3)
        {
            _barricadePlank[3].SetActive(false);
        }
        if (_barricade.activeSelf && _barricadeCurrentHP <= (_barricadeMaxHP/2))
        {
            _barricadePlank[2].SetActive(false);
        }
        if (_barricade.activeSelf && _barricadeCurrentHP <= _barricadeMaxHP/4)
        {
            _barricadePlank[1].SetActive(false);
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

            for (int i = 0; i < 4; i++)
            {
                _barricadePlank[i].SetActive(true);
            }
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

    private void IsBuildOff()
    {
        isBuild = false;
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
