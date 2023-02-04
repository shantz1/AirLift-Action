using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // The prefab for the bullet
    public Transform bulletSpawnPoint; // The spawn point for the bullets
    public float bulletSpeed = 1f; // The speed at which the bullet will travel
    public float bulletsPerSecond = 10f; // The number of bullets that will spawn per second
    public float range = 25f; // The maximum shooting range
    public AudioSource shootingSound; // The audio source for the shooting sound
    public string enemyTag = "Enemy"; // The tag for enemy objects
    public Transform rayStartPoint; // The starting point of the ray
    private float lastShotTime; // The time when the last bullet was spawned
    private float shootInterval;


    //Object pooling
    private Queue<GameObject> bulletPool;
    public int poolSize = 10;

    private void OnEnable()
    {
        UpdateBulletFireRate();
        CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    private void UpdateBulletFireRate()
    {
        shootInterval = 1 / bulletsPerSecond;
    }

    void Update()
    {
        if (Time.time >= lastShotTime + shootInterval)
        {
            if (ShouldShoot())
            {
                SpawnBullet();
            }
            lastShotTime = Time.time;
        }

        // Draw the ray for debugging purposes
        Debug.DrawRay(rayStartPoint.position, rayStartPoint.forward * range, Color.red);
    }

    private bool ShouldShoot()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, range);

        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag(enemyTag))
                return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(rayStartPoint.position, rayStartPoint.position + rayStartPoint.forward * range);
    }

    private void SpawnBullet()
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
        bulletPool.Enqueue(bullet);

        // Play the shooting sound
        shootingSound.Play();
    }

    private void OnValidate()
    {
        UpdateBulletFireRate();
    }
}