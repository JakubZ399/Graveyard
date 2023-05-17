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
    private void Start()
    {
        respawnPointPos = respawnPoint.position;
        for(int i = 0; i < firstWave; i++)
        {
            Instantiate(enemyPrefab,respawnPointPos, Quaternion.identity);
        }
    }
}
