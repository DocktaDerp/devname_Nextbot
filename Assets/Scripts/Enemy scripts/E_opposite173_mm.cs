using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_opposite173_mm : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point)< 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update ()
    {
        var targetRender = target.GetComponent<Renderer>();
        if (IsVisible(cam,target))
        {
           GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
        else
        {
           GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
    }
}
