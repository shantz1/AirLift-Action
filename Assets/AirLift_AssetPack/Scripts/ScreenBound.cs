using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBound : MonoBehaviour
{
    private Vector3 minBound,maxBound;
    
    

    void LateUpdate()

    {
        var cameraDepth = Mathf.Abs(Camera.main.transform.position.x - transform.position.x);
        minBound = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, cameraDepth));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector3(.95f, .95f, cameraDepth));

        Vector3 viewPos = transform.position;
        viewPos.z= Mathf.Clamp(viewPos.z, minBound.z, maxBound.z);
        viewPos.y= Mathf.Clamp(viewPos.y, minBound.y, maxBound.y);

        viewPos.x = Mathf.Clamp(transform.position.x, -20,-5);

        transform.position = viewPos;
    }
}
