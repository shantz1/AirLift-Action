﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
