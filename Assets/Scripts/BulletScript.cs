using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject Enemy;
    public float speed;
    private Rigidbody2D rb;
    private GameObject playerBullets;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right  * speed;
    }

    // Update is called once per frame
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Enemy enemy = collision.GetComponent<Enemy>();
    //    if(enemy !=null)
    //    {
    //        enemy.TakeDamage(20);
    //    }
    //    Instantiate(playerBullets, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}
}
