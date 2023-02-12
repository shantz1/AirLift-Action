using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediBoxItem : MonoBehaviour
{
    public void FixedUpdate()
    {
        transform.Rotate(0,10,0);
    }

    public void OnCollisionEnter(Collision collider)
    {

        if (collider.collider.CompareTag("PlayerJeep"))
        {
            //   playerhealth.HealthIncrease(); //I have called that function from healthcs here got it bro
            Destroy(gameObject);
        }
    }
}
