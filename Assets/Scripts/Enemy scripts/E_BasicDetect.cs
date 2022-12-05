using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BasicDetect : MonoBehaviour
{
    public Transform eyes_tf;
    int layer_mask;
    // Start is called before the first frame update
    void Start()
    {
        layer_mask = LayerMask.GetMask("groundLayer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider player)
    {
        bool cantSee = Physics.Linecast(eyes_tf.position, player.GetComponent<Transform>().position, layer_mask);

        if (cantSee == false)
        {
            Debug.Log("yippee :33");
            this.gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }
}
