using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float damage = 1f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
        
            health -= damage;
        
        }
    }
   public void TakeDamage(float damagePoints)
    {
       
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        
        Destroy(gameObject);
    
    
    }

    
}
