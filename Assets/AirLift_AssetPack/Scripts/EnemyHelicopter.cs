using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelicopter : MonoBehaviour

{
    public GameObject mainRotor;
    public GameObject tailRotor;
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
    
    private Quaternion targetRotation;
    public float smooth = 5.0f;

    //Object pooling
    private Queue<GameObject> bulletPool;
    public int poolSize = 10;

    private void OnEnable()
    {
        UpdateBulletFireRate();
        CreateBulletPool();
    }

    void FixedUpdate()
    {


        RotorRotation();




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

        Destroy(gameObject, 8f);
    }

    private bool ShouldShoot()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, range);

        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag(enemyTag))
                return false;
        }

        return true;
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

        shootingSound.pitch = UnityEngine.Random.Range(1f, 1.2f);
        shootingSound.Play();
    }

    private void OnValidate()
    {
        UpdateBulletFireRate();
    }

    void RotorRotation()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        // Rotate the main rotor

        if (mainRotor != null)
        {
            mainRotor.transform.Rotate(0, 500, 0);
        }
        if (tailRotor != null)
        {
            // Rotate the tail rotor on its pivot point
            tailRotor.transform.Rotate(500, 0, 0);
        }













    }

}
