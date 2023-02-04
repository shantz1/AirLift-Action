using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;
   
   
    
    private void Awake()
    {
        currentHealth = maxHealth;
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
    }

    private void Die()
    {
        // Trigger game over
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            currentHealth = currentHealth-1;
        }
    }

    






}
    

