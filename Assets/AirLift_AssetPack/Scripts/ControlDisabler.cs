using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDisabler : MonoBehaviour
{
    public FixedJoystick fixedjoystik;
    public Button FireButton;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        fixedjoystik.enabled = false;



    }


 







}
