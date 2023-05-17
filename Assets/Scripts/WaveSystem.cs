using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("How many enemy to spawn?")]
    public int firstWave = 5;
    public int secondWave = 10;
    public int thirdWave = 15;
    
    [Header("Things to choose")]
    
    //respawn points to choose
    public Transform respawnPoint;
    
    //enemy prefab to choose
    public GameObject enemyPrefab;

    public Vector3 respawnPointPos;
    private int timerValue;

    private bool isFristWave;
    private bool isSecondWave;
    private bool isThirdWave;
    
    private void Start()
    {
        respawnPointPos = respawnPoint.position;
    }

    private void Update()
    {
        timerValue = Mathf.FloorToInt(Timer.timeValueStatic);
        if (timerValue == 110 && !isFristWave)
        {
            SpawnEnemy(firstWave);
            isFristWave = true;
        }
        else if (timerValue == 60 && !isSecondWave)
        {
            SpawnEnemy(secondWave);
            isSecondWave = true;
        }
        else if (timerValue == 30 && !isThirdWave)
        {
            SpawnEnemy(thirdWave);
            isThirdWave = true;
        }
    }

    void SpawnEnemy(int enemyQuantity)
    {
        for (int i = 0; i < enemyQuantity; i++)
        {
            Instantiate(enemyPrefab,respawnPointPos, Quaternion.identity);
        }
    }
}
