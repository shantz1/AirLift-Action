using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f; // Speed variable that can be adjusted in the Inspector window
    public bool moveForward = true; // Direction of movement (forward or backward) that can be set in the Inspector window

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); // Move object forward in the Z axis
        }
        else
        {
            transform.Translate(0, 0, -speed * Time.deltaTime); // Move object backward in the Z axis
        }
    }
}




