using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediBoxItem : MonoBehaviour
{
    public void FixedUpdate()
    {
        transform.Rotate(0, 5, 0);
    }

    public void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("PlayerJeep"))
        {
            //   playerhealth.HealthIncrease(); //I have called that function from healthcs here got it bro
            Destroy(gameObject);
        }
    }
}
