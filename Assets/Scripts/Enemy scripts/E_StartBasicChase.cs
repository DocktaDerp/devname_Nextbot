using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_StartBasicChase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canSeePlayer = GetComponent<E_FieldOfView>().canSeePlayer;
        if(canSeePlayer)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }
}
