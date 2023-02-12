using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    public Health playerhealth;
   public GameObject Medkit; // Drag the enemy prefab into this field in the Unity editor
    public float spawnInterval = 20.0f; // Time between spawns in seconds
    public float spawnDistance = 30.0f; // Distance at which to spawn enemies

    private float lastSpawnTime; // Time of last spawn
   
    void FixedUpdate()
    {
        // Check if it's time to spawn an enemy
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            // Spawn an enemy at a random location along the spawnDistance
            Vector3 spawnPos = transform.position + new Vector3(0, 0, Random.Range(-spawnDistance, spawnDistance));
            Instantiate(Medkit, spawnPos, Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }

    
    //fastforwar ok bro check it I am here
    //public void OnTriggerEnter(Collider collider)
    //{

    //    if (collider.CompareTag("PlayerJeep"))
    //    {
    //        Debug.Log("Medkit Recieved");
    //        playerhealth.HealthIncrease(); //I have called that function from healthcs here got it bro

    //        Destroy(Medkit,0.1f);
    //    }
    //}// is it worked before? yes when we created medibox and attached script to it, it worked

}