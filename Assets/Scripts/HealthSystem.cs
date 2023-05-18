using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public static int currentPlayerHealthStatic;
    private bool isAlive;

    private void Start()
    {
        currentPlayerHealthStatic = 100;
        isAlive = true;
    }

    private void Update()
    {
        SetMaxPlayerHealth();
        Debug.Log(currentPlayerHealthStatic);
        RestartLevel();
    }

    private void RestartLevel()
    {
        if(currentPlayerHealthStatic <= 0 && isAlive)
        {
            isAlive = false;
            Destroy(gameObject);
            Invoke("ReloadLevelAfterTime", 1f);
        }
    }

    private void ReloadLevelAfterTime()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetMaxPlayerHealth()
    {
        if (currentPlayerHealthStatic > 100)
        {
            currentPlayerHealthStatic = 100;
        }
    }
}
