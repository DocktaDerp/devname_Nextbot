using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public GameObject HPCounter;
    public int Mhealth = 100;
    static int Chealth = 10;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        Text text = HPCounter.GetComponent<Text>();
        text.text = Chealth.ToString() + "/" + Mhealth.ToString();
    }

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
