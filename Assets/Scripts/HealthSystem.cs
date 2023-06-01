using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public static int currentPlayerHealthStatic;

    private void Start()
    {
        currentPlayerHealthStatic = 100;
    }

    private void Update()
    {
        SetMaxPlayerHealth();
        RestartLevelAfterDead();
    }

    private void RestartLevelAfterDead()
    {
        if(currentPlayerHealthStatic <= 0)
        {
            StartCoroutine(ReloadLevelAfterTime());
        }
    }

    private IEnumerator ReloadLevelAfterTime()
    {
        yield return new WaitForSeconds(1f);
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
