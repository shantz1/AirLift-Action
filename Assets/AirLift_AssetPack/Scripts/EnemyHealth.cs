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
    private TakedownCounter takedownCounter;

    private void Awake()
    {
        health = maxHealth;
        dead = false;
        takedownCounter = FindObjectOfType<TakedownCounter>();
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

        if (health <= 0 && !dead)
        {
            dead = true;
            takedownCounter.AddTakedown();
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
            health -= 10;
            SoundManager.Instance.PlaySound(SoundManager.Instance.Truck);
        
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
