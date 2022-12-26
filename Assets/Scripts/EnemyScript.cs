using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2;
    [SerializeField]
    private float health;
    public GameObject enemyBullets;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(enemyBullets, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        if(transform.position.x <= -20)
        {
            Destroy(this.gameObject);
        }
    }
}
