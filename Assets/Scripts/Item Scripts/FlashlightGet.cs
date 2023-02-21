using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightGet : MonoBehaviour
{
    //Script (Ussually Flashlight) for this script to send info to
    [SerializeField] Flashlight flashlight;
    //Held Flashlight model
    [SerializeField] GameObject flashlightHand;

    void Start()
    {
        flashlightHand.gameObject.SetActive(false);
    }

    //Trigger to pickup Flashlight and destroy flashlight pickup object
    private void OnTriggerEnter(Collider other)
    {
        flashlight.FlashlightObjectHave = true;
        Destroy(gameObject);
        flashlightHand.gameObject.SetActive(true);
    }
}
