using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{   [SerializeField]
    EZPatrol patrol;
    [SerializeField]
    Material red;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            gameObject.GetComponent<MeshRenderer>().material = red;
            patrol.TargetPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.body.gameObject.tag == "Player") 
        {
            collision.rigidbody.AddForce(100000, 100000, 100000);
        }
    }
}
