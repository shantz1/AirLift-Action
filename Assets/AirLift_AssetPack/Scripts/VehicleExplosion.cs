using System.Collections;
using UnityEngine;

public class VehicleExplosion : MonoBehaviour
{
    public GameObject[] explodableParts;
    public GameObject explosionParticles;
    public float explosionForce = 1000.0f;
    public float explosionRadius = 10.0f;
    public float shrinkDuration = 2.0f;

    private Vector3 originalScale;
    private float startTime;
    private bool isExploded = false;
    private Rigidbody[] explodableRigidbodies;

    private EnemyHealth Health;



    private void Start()
    {
        Health = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        if (Health.dead)
        {
            Explode();
        }
        
        if(isExploded)

        {
           Destroy(gameObject,0.5f);//destroy the entire object
           
        }
        
        
        
    }

    public void Explode()
    {
        if (!isExploded)
        {
            originalScale = transform.localScale;
            explodableRigidbodies = new Rigidbody[explodableParts.Length];
            for (int i = 0; i < explodableParts.Length; i++)
            {
                explodableRigidbodies[i] = explodableParts[i].AddComponent<Rigidbody>();
                explodableRigidbodies[i].isKinematic = false;
                explodableRigidbodies[i].AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            startTime = Time.time;
            isExploded = true;
            
        }
    }

   
}
