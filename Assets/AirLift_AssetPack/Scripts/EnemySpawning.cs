using System.Collections;
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
    public float initialDelay = 0f; // added initial delay option

    private int waveIndex = 0;

    private void Start()
    {
        
        StartCoroutine(SpawnWithInitialDelay()); // call the new method with delay
    }

    IEnumerator SpawnWithInitialDelay()
    {
        yield return new WaitForSeconds(initialDelay); // wait for the initial delay
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (waveIndex == waves.Length)
            {
                waveIndex = 0; // cycle back to the first wave
            }

            // spawn the current wave with time intervals between each enemy
            yield return StartCoroutine(SpawnEnemies(waveIndex));
            waveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
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
