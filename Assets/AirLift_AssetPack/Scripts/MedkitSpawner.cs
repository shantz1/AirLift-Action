using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;
    public Transform[] spawnPoints;
    public string overlapTag;
    public string enemyTag;

    void Start()
    {
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnObject()
    {
        // Select a random spawn point
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnPointIndex].position;

        // Check if there are any objects or enemy objects within a certain radius of the spawn point
        Collider[] colliders;
        bool canSpawn = false;
        int attempts = 0;
        while (!canSpawn && attempts < spawnPoints.Length)
        {
            colliders = Physics.OverlapSphere(spawnPosition, objectToSpawn.transform.localScale.x);
            bool overlapFound = false;
            bool enemyFound = false;
            foreach (Collider col in colliders)
            {
                if (col.CompareTag(overlapTag))
                {
                    overlapFound = true;
                }
                if (col.CompareTag(enemyTag))
                {
                    enemyFound = true;
                }
            }
            if (!overlapFound && !enemyFound)
            {
                canSpawn = true;
            }

            // If we can't spawn at this spawn point, select another random spawn point
            if (!canSpawn)
            {
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                spawnPosition = spawnPoints[spawnPointIndex].position;
                attempts++;
            }
        }

        // If we can spawn, instantiate the object at the selected spawn point
        if (canSpawn)
        {
            Instantiate(objectToSpawn, spawnPosition, spawnPoints[spawnPointIndex].rotation);

        }


        // Schedule the next spawn time
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerJeep"))
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.Truck);
        }
    }
}