using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }


        if (Input.GetKey(KeyCode.D)) 
        {

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Player has touched " + collision.gameObject.name);
    }
}
