using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ObjectHit script is attached to Wall to do smt when smt collides into the wall
// attached to other obstacles as well
public class ObjectHit : MonoBehaviour
{
    // built in callback that will be triggered by wall upon being collided
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            // get component MeshRenderer using GetComponent<>()
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
    }
}
