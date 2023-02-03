using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    [SerializeField]
    private float speed = 20;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}
