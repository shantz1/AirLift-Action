using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}
