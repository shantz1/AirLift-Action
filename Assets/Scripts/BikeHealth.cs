using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 30f;
    public GameObject healthBarUI;
    public Slider healthSlider;



    private void Awake()
    {
        health = maxHealth;
    }

    public void Update()
    {
        healthSliderUI();
    }


    public void healthSliderUI()
    {

        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = health;

        if (health <= 0)
        {
            DestroyBike();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void DestroyBike()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            health--;
        }
        if (collision.gameObject.CompareTag("PlayerJeep"))
        {
            health--;
        }
    }

  

}


