﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    public GameObject enemyType;
    public int enemyCount;
}

[System.Serializable]
public class Wave
{
    public string waveName;
    public WaveEnemy[] waveEnemies;
}

public class EnemySpawning : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 1f;

    private int waveIndex = 0;

    private void Start()
    {
        InvokeRepeating("SpawnWave", 0f, timeBetweenWaves);
    }

    void SpawnWave()
    {
        if (waveIndex == waves.Length)
        {
            // all waves have been completed
            CancelInvoke("SpawnWave");
            return;
        }

        // spawn the current wave with time intervals between each enemy
        StartCoroutine(SpawnEnemies(waveIndex));
        waveIndex++;
    }

    IEnumerator SpawnEnemies(int waveIndex)
    {
        for (int i = 0; i < waves[waveIndex].waveEnemies.Length; i++)
        {
            for (int j = 0; j < waves[waveIndex].waveEnemies[i].enemyCount; j++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(waves[waveIndex].waveEnemies[i].enemyType, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
    }
}