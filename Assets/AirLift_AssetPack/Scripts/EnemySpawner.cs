using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTankPrefab; // drag and drop the enemy tank prefab in the inspector
    public float spawnInterval = 2f; // time interval between spawning of enemy tanks
    public float enemySpeed = 0.1f; // speed at which the enemy tanks move
    public GameObject player; // drag and drop the player object in the inspector
    public GameObject bulletPrefab; // drag and drop the bullet prefab in the inspector
    public float bulletSpeed = 5f; // speed at which the bullets move
    public float fireInterval = 1f; // time interval between firing of bullets


    private float spawnTimer = 0f;
    private float fireTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemyTank();
        }
    }

    void SpawnEnemyTank()
    {
        GameObject enemyTank = Instantiate(enemyTankPrefab, transform.position, Quaternion.identity) as GameObject;
        enemyTank.GetComponent<Rigidbody>().velocity = new Vector3(-enemySpeed, 0, 0);

        StartCoroutine(FireBullets(enemyTank));
    }

    IEnumerator FireBullets(GameObject enemyTank)
    {
        while (true)
        {
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireInterval)
            {
                fireTimer = 0f;

                GameObject bullet = Instantiate(bulletPrefab, enemyTank.transform.position, Quaternion.identity) as GameObject;
                Vector3 bulletDirection = player.transform.position - bullet.transform.position;
                bulletDirection.Normalize();
                bullet.GetComponent<Rigidbody>().velocity = bulletDirection * bulletSpeed;
            }

            yield return null;
        }

    }

}