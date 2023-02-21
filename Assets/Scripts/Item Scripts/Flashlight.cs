using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //Held Flashlight model
    [SerializeField] GameObject FlashlightLight;
    //The bulb of the flashlight
    [SerializeField] GameObject FlashlightBulb;
    private bool FlashlightActive = false;
    public bool FlashlightObjectHave = false;

    void Start()
    {
        //Setting Held model and bulb as disabled
        FlashlightLight.gameObject.SetActive(false);
        FlashlightBulb.gameObject.SetActive(false);
    }

    
    void Update()
    {
        //Calling function that allows use of flashlight
        FlashlightLightactivate();
    }

    //Function that checks to see if you have the flashlight and if you have pressed "F" key to turn light on and off
    void FlashlightLightactivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false && FlashlightObjectHave == true)
            {
                FlashlightLight.gameObject.SetActive(true);
                FlashlightBulb.gameObject.SetActive(true);
                FlashlightActive = true;
            }
            else
            {
                FlashlightLight.gameObject.SetActive(false);
                FlashlightBulb.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}

