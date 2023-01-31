using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    
    public float waitCheck = 0.1f;
    GameObject destinationObj;
    public float extraDetectTime = 0.25f;
    bool afterSee = false;
    float timer = 0;

    private void Start()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    //basically function that executes every waitCheck seconds
    private IEnumerator FOVRoutine()
    {

        destinationObj = GameObject.Find(this.name + "_T");
        WaitForSeconds wait = new WaitForSeconds(waitCheck);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        // check if circle collides with object
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            //target is player
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //if player is in view
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //shoot raycast to see if the player is not behind a wall
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    destinationObj.transform.position = target.position;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void FixedUpdate() 
    {
        if(canSeePlayer)
        {
            afterSee = true;
            timer = extraDetectTime;
        }
        else if (afterSee == true)
        {
            timer = timer - Time.deltaTime;
        }

        if(timer > 0)
        {
            GameObject.Find(this.name + "_T").transform.position = playerRef.transform.position;
        }
        else {afterSee = false;}
    }
}

