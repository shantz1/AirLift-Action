using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed = 20f;

    private void OnEnable()
    {

        Invoke("Hide", 2f);
    
     }


    void Update()

    {

        transform.position += transform.forward * BulletSpeed * Time.deltaTime;

          
          transform.Translate(0, 0, BulletSpeed * Time.deltaTime);
    }

      void Hide()
     {
       this.gameObject.SetActive(false);
     }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
       

    }



}





