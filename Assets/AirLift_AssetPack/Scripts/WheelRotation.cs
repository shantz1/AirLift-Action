using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float speed = 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed*Time.deltaTime);
    }
}
