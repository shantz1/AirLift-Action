using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class ShootScript : MonoBehaviour
{
    private float horizontal, vertical;
    public  float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] public Transform shootingPoint;
    [SerializeField] public GameObject bulletPrefab;




    // Update is called once per frame
    void Update()


    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Fire();

        }

    }

    private void FixedUpdate()
    {
            rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    }

    private void Fire()
    {

        GameObject bullet = BulletScript.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = shootingPoint.position;
            bullet.SetActive(true);
        }


    }

}
