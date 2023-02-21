using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    //Object that contains text component, best if in UI
    public GameObject HPCounter;
    public int Mhealth = 100;
    static int Chealth = 10;
    private Text text;
    
    void Start()
    {
        //Setting health at inital values
        Text text = HPCounter.GetComponent<Text>();
        text.text = Chealth.ToString() + "/" + Mhealth.ToString();
    }

    //When the player object collides with an item with this script it will increment Health by 10 and destroy the object
    private void OnTriggerEnter(Collider other)
    {
        Interlocked.Add(ref Healing.Chealth, 10);
        Destroy(gameObject);
        Debug.Log(Chealth);
        if (Chealth > Mhealth)
        {
            Chealth = Mhealth;
        }
        Text text = HPCounter.GetComponent<Text>();
        text.text = Chealth.ToString() + "/" + Mhealth.ToString();

    }
}
