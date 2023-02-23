using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;
    public bool gameOver = false;
    public GameObject gameOverUI;

    public GameObject[] explodableParts;
    public GameObject explosionParticles;
    public float explosionForce = 1000.0f;
    public float explosionRadius = 10.0f;
    public float shrinkDuration = 2.0f;

    private Vector3 originalScale;
    private float startTime;
    private bool isExploded = false;
    private Rigidbody[] explodableRigidbodies;

    private void Awake()
    {
        currentHealth = 100;
    }

    public void Update()
    {
        healthSliderUI();
       
    }

    public void healthSliderUI()
    {

        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        Explode();
        gameOver = true;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            currentHealth -= 20;
        }

        if (collision.collider.CompareTag("PlayerCoptor"))
        {

            Die();

        }

    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyBullet")
        {
            currentHealth--;
        }
        if (collider.tag == "Medikit")
        {
            currentHealth = maxHealth;
        }
    }

    public void HealthIncrease()
    {
        currentHealth = maxHealth;
    }


    public void Explode()
    {
        if (!isExploded)
        {
            originalScale = transform.localScale;
            explodableRigidbodies = new Rigidbody[explodableParts.Length];
            for (int i = 0; i < explodableParts.Length; i++)
            {
                explodableRigidbodies[i] = explodableParts[i].AddComponent<Rigidbody>();
                explodableRigidbodies[i].isKinematic = false;
                explodableRigidbodies[i].AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            startTime = Time.time;
            isExploded = true;

        }
    }
}
