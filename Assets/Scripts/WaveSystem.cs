using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int firstWave = 5;
    public Transform respawnPoint;
    public GameObject enemyPrefab;

    private Vector3 respawnPointPos;
    private int timerValue;
    
    private void Start()
    {
        respawnPointPos = respawnPoint.position;
    }

    private void Update()
    {
        timerValue = Mathf.FloorToInt(Timer.timeValueStatic);
        Debug.Log(timerValue);
        if (timerValue == 115)
        {
            Instantiate(enemyPrefab,respawnPointPos, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}
