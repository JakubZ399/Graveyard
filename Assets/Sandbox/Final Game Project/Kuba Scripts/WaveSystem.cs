using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSystem : MonoBehaviour
{
    [Header("How many enemy to spawn?")]
    public int firstWave = 5;
    public int secondWave = 10;
    public int thirdWave = 15;

    [Header("Time to respawn waves")]
    public int firstWaveTimer = 110;
    public int secondWaveTimer = 80;
    public int thirdWaveTimer = 40;
    
    [Header("Things to choose")]
    
    //respawn points to choose
    public Transform[] respawnPoint;
    
    //enemy prefab to choose
    public GameObject enemyPrefab;
    
    public Vector3[] respawnPointPos;
    
    
    private int timerValue;

    private bool isFristWave;
    private bool isSecondWave;
    private bool isThirdWave;
    
    private void Start()
    {
        //get respawnpoints position for array
        for (int i = 0; i <= respawnPoint.Length - 1; i++)
        {
            respawnPointPos[i] = respawnPoint[i].position;
        }

    }

    private void Update()
    {
        SpawnWaves();
    }

    void SpawnEnemy(int enemyQuantity)
    {
        for (int i = 0; i <= respawnPoint.Length - 1; i++)
        {
            StartCoroutine(DelayEnemySpawn(i, enemyQuantity));
        }
    }

    void SpawnWaves()
    {
        timerValue = Mathf.FloorToInt(Timer.timeValueStatic);
        
        if (timerValue == firstWaveTimer && !isFristWave)
        {
            SpawnEnemy(firstWave);
            isFristWave = true;

            HealthSystem.currentPlayerHealthStatic = 100;
        }
        else if (timerValue == secondWaveTimer && !isSecondWave)
        {
            SpawnEnemy(secondWave);
            isSecondWave = true;

            HealthSystem.currentPlayerHealthStatic = 100;
        }
        else if (timerValue == thirdWaveTimer && !isThirdWave)
        {
            SpawnEnemy(thirdWave);
            isThirdWave = true;

            HealthSystem.currentPlayerHealthStatic = 100;
        }
    }

    private IEnumerator DelayEnemySpawn(int i, int enemyQuantity)
    {
        
        for (int x = Random.Range(1, enemyQuantity-1); x < enemyQuantity; x++)
        {
            Instantiate(enemyPrefab,respawnPointPos[i], Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
