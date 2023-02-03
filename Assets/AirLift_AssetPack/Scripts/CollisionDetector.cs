using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameManager gameManager;
    public SceneController sceneController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.ScoreIncrease();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyTruck"))
        {
            
            sceneController.ReloadScene();
        }

    }

}
