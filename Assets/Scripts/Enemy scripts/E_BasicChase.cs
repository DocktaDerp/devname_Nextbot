using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E_BasicChase : MonoBehaviour
{
    NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.enabled == true)
        {
            enemy.SetDestination(GameObject.Find(this.name + "_T").transform.position);
            //enemy.SetDestination(GameObject.Find("Player").transform.position);
        }
    }
}
