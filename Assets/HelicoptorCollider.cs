using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicoptorCollider : MonoBehaviour
{

    public GameObject[] explodableParts;
    public GameObject explosionParticles;
    public float explosionForce = 1000.0f;
    public float explosionRadius = 10.0f;
    public float shrinkDuration = 2.0f;
    public bool gameOver = false;
    public GameObject gameOverUI;

    private Vector3 originalScale;
    private float startTime;
    private bool isExploded = false;
    private Rigidbody[] explodableRigidbodies;


    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Explode();
            SoundManager.Instance.PlaySound(SoundManager.Instance.Truck);
            Destroy(gameObject, 0.5f);
            gameOver = true;
        }

        if (collision.collider.CompareTag("Terrain"))
        {
            Explode();
            SoundManager.Instance.PlaySound(SoundManager.Instance.Truck);
            Destroy(gameObject, 0.5f);
            gameOver = true;
        }

        if (collision.collider.CompareTag("PlayerJeep"))
        {
            Explode();
            SoundManager.Instance.PlaySound(SoundManager.Instance.Truck);
            Destroy(gameObject, 0.5f);
            Destroy(collision.gameObject, 0.5f);
            gameOver = true;
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
