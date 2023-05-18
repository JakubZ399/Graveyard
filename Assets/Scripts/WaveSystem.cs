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
    
    [Header("Things to choose")]
    
    //respawn points to choose
    public Transform[] respawnPoint;
    
    //enemy prefab to choose
    public GameObject enemyPrefab;
    
    //Vector 3
    public Vector3 respawnPointPos;
    
    //private
    private int timerValue;

    private bool isFristWave;
    private bool isSecondWave;
    private bool isThirdWave;
    
    private void Start()
    {
        respawnPointPos = respawnPoint[Random.Range(0, respawnPoint.Length-1)].position;
    }

    private void Update()
    {
        SpawnWaves();
    }

    void SpawnEnemy(int enemyQuantity)
    {
        for (int i = 0; i < enemyQuantity; i++)
        {
            Instantiate(enemyPrefab,respawnPointPos, Quaternion.identity);
        }
    }

    void SpawnWaves()
    {
        timerValue = Mathf.FloorToInt(Timer.timeValueStatic);
        
        //110
        if (timerValue == 117 && !isFristWave)
        {
            SpawnEnemy(firstWave);
            isFristWave = true;
        }
        //60
        else if (timerValue == 60 && !isSecondWave)
        {
            SpawnEnemy(secondWave);
            isSecondWave = true;
        }
        //30
        else if (timerValue == 30 && !isThirdWave)
        {
            SpawnEnemy(thirdWave);
            isThirdWave = true;
        }
    }
}
