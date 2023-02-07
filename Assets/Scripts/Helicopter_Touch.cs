using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter_Touch : MonoBehaviour

{
    public float speed = 10.0f;
    public float pitchAmount = 10.0f;
    public float rotationSpeed = 10.0f;
    public GameObject mainRotor;
    public GameObject tailRotor;
    private Rigidbody rb;
    private float moveHorizontal;
    private float moveVertical;


    //x movement
    private float Tilting;
    [SerializeField]
    private FixedJoystick joystick;




    private Quaternion targetRotation;
    public float smooth = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveHorizontal = joystick.Direction.x;
   
        Tilting = joystick.Direction.y;
        

        Vector3 movement = new Vector3(-Tilting, 0, moveHorizontal);
      
        rb.velocity = movement * speed;

     
        targetRotation = Quaternion.Euler(moveHorizontal * pitchAmount, 0, Tilting * pitchAmount);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        // Rotate the main rotor
        mainRotor.transform.Rotate(0, 0, rotationSpeed);
        // Rotate the tail rotor on its pivot point
        tailRotor.transform.RotateAround(tailRotor.transform.position, tailRotor.transform.right, -rotationSpeed * 2);





    }
}
