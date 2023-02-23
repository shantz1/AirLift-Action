using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    public VehicleExplosion ve;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("PlayerCoptor"))
        {
            ve.Explode();

            Destroy(gameObject, 0.5f);
        }
    }
}
