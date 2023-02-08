using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightGet : MonoBehaviour
{
    [SerializeField] Flashlight flashlight;
    [SerializeField] GameObject flashlightHand;

    void Start()
    {
        flashlightHand.gameObject.SetActive(false);
    }

    //Trigger to pickup Flashlight.
    private void OnTriggerEnter(Collider other)
    {
        flashlight.FlashlightObjectHave = true;
        Destroy(gameObject);
        flashlightHand.gameObject.SetActive(true);
    }
}
