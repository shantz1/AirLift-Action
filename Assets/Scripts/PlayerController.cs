using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    public GameManager gameManager;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!gameManager.gameOver)
        {

            if (Input.GetKey(KeyCode.W))
            {

                MoveUp();
            }
            if (Input.GetKey(KeyCode.S))
            {
                MoveDown();


            }


            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();


            }

            if (Input.GetKey(KeyCode.A))
            {

                MoveLeft();
            }
        }

    }


    public void MoveUp()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void MoveDown()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void MoveRight()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
    public void MoveLeft()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Player has touched " + collision.gameObject.name);
    }
}