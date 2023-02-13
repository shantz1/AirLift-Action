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
   
   
    
    private void Awake()
    {
        currentHealth =100;
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
        if(currentHealth > maxHealth)
        {
            currentHealth= maxHealth;
        }
    }

    public void Die()
    {
        gameOver= true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            currentHealth--;
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
            Debug.Log("Medkit Recieved in health script");
            currentHealth = maxHealth;
        }
    }

    


    public void HealthIncrease()
    {
        currentHealth = maxHealth;
    }
}
//we can do this also ok bro