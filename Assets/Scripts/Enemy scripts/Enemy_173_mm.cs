using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_173_mm : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    public Transform cam_tf;
    int layer_mask;
    bool cantSee;

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

    
    private void Start() 
    {
        layer_mask = LayerMask.GetMask("groundLayer");
    }

    private void Update ()
    {
        
        cantSee = Physics.Linecast(transform.position, cam_tf.position, layer_mask);
        
        var targetRender = target.GetComponent<Renderer>();
        if (IsVisible(cam,target) && cantSee == false)
        {
           GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
        else 
        {
           GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }

    }
}
