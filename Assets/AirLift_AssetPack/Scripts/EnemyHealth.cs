using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject game_Object;
    public float maxHealth = 50f;
    public GameObject healthBarUI;
    public Slider healthSlider;
    private VehicleExplosion explosion;
    public bool dead = false;




    private void Awake()
    {
        health = maxHealth;

        dead = false;
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
            dead = true;


        }



        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }



    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("PlayerJeep"))
        {
            health--;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            health--;
        }
    }
}


