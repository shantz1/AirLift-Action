using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepHealth : MonoBehaviour
{

    public Health health;
    
    void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.tag == "Bullet")
        {
            health.currentHealth = health.currentHealth-1;
        }
    }
}
