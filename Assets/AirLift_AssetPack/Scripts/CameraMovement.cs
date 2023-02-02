using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement: MonoBehaviour
{
   

    public float speed = 5f; // Speed variable that can be adjusted in the Inspector window
    public bool moveForward = true; // Direction of movement (forward or backward) that can be set in the Inspector window

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            transform.position += transform.right * speed * Time.deltaTime; // Move camera forward in the Z axis using its global transform
        }
        else
        {
            transform.position -= transform.forward * speed * Time.deltaTime; // Move camera backward in the Z axis using its global transform
        }
    }


}
