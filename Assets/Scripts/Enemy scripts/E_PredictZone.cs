using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class E_PredictZone : MonoBehaviour
{
    public float playerMaxSpeed;
    public float radius;
    public LayerMask targetMask;

    void FixedUpdate()
    {
        PredictZoneCheck();
    }
    private void PredictZoneCheck()
    {
        radius = radius + playerMaxSpeed;
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            for(int i = 0; i < rangeChecks.Length; i++)
            {
                if(rangeChecks[i].tag != "PointOfInterest")
                {
                    rangeChecks[i].tag = "PointOfInterest";
                }
            }
        }
    }
}
