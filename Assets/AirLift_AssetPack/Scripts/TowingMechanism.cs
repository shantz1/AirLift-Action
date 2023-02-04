using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowingMechanism : MonoBehaviour
{
    public GameObject helicopter;
    public GameObject jeep;
    public float speed = 5f;
    public LineRenderer lineRenderer;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = jeep.transform.position;
    }

    void Update()
    {
        // Update the target position for the jeep based on the helicopter's Z position
        targetPos.z = helicopter.transform.position.z;
        targetPos.x = helicopter.transform.position.x;

        // Move the jeep towards the target position
        jeep.transform.position = Vector3.Lerp(jeep.transform.position, targetPos, Time.deltaTime * speed);

        // Update the positions of the line renderer
        lineRenderer.SetPosition(0, helicopter.transform.position);
        lineRenderer.SetPosition(1, jeep.transform.position);
    }
}


