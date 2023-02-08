using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] GameObject FlashlightBulb;
    private bool FlashlightActive = false;
    public bool FlashlightObjectHave = false;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false);
        FlashlightBulb.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightLightactivate();
    }

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

