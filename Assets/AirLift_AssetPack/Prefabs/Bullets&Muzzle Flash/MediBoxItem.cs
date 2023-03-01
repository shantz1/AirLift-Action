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
            //   playerhealth.HealthIncrease(); 
            Destroy(gameObject);
            SoundManager.Instance.PlaySound(SoundManager.Instance.healthGain);
        }
    }
}
