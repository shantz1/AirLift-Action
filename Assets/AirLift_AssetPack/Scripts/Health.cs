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
        if(currentHealth > maxHealth)
        {
            currentHealth= maxHealth;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
           // currentHealth--;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
           //
        }


    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            currentHealth--;
        }
        if (collider.CompareTag("Bullet"))
        {
            currentHealth += 10;
        }

    }




}
    

