using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public Health playerhealth;
    
    public GameObject HealthPrefab; // Drag the enemy prefab into this field in the Unity editor
    public float spawnInterval = 20.0f; // Time between spawns in seconds
    public float spawnDistance = 30.0f; // Distance at which to spawn enemies

    private float lastSpawnTime; // Time of last spawn

    void Update()
    {
        // Check if it's time to spawn an enemy
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            // Spawn an enemy at a random location along the spawnDistance
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), 0, 0);
            Instantiate(HealthPrefab, spawnPos, Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("PlayerJeep"))
        {
            playerhealth.HealthIncrease();
            Destroy(HealthPrefab);
        }
    }
}