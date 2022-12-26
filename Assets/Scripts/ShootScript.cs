using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject BulletIns =  Instantiate(bulletPrefab, shootingPoint.position, transform.rotation) ;
            Destroy(BulletIns, 3);
        }

    }



}
