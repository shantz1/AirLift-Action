using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootingSound;
    public float sphereCastRadius = 5f;
    public float attackDelay = 5f;
    public float fireRateMin = 1f;
    public float fireRateMax = 2f;
    public int numberOfBulletsMin = 3;
    public int numberOfBulletsMax = 5;
    public float bulletSpawnTimeMin = 0.1f;
    public float bulletSpawnTimeMax = 0.5f;

    private float attackValue;
    private bool isShooting;
    private bool playerInRange;

    private void Awake()
    {
        StartCoroutine(IncreaseAttackValue());
    }

    private void Update()
    {
        CheckPlayerInRange();
        if (attackValue >= attackDelay && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private void CheckPlayerInRange()
    {
        RaycastHit hit;
        if (Physics.SphereCast(firePoint.position, sphereCastRadius, firePoint.forward, out hit, 25f))
        {
            if (hit.collider.CompareTag("PlayerJeep"))
            {

                playerInRange = true;
                return;
            }
        }

        playerInRange = false;
    }

    private IEnumerator IncreaseAttackValue()
    {
        while (true)
        {
            if (playerInRange)
            {
                attackValue++;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        int numberOfBullets = Random.Range(numberOfBulletsMin, numberOfBulletsMax + 1);
        for (int i = 0; i < numberOfBullets; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shootingSound.Play();

            float bulletSpawnTime = Random.Range(bulletSpawnTimeMin, bulletSpawnTimeMax);
            yield return new WaitForSeconds(bulletSpawnTime);
        }
        attackValue = 0f;

        isShooting = false;
    }
}
