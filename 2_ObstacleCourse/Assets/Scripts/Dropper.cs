using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to drop the object
public class Dropper : MonoBehaviour
{
    MeshRenderer renderer; 
    Rigidbody rigidbody;
    [SerializeField] float timeToWait = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // get the component at the start of the frame
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;   // the object is set to be invisible on game screen using .enabled
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.time: a timer
        // When time elapsed > wait time, 
        if(Time.time > timeToWait)
        {
            renderer.enabled = true;    // the object is set to be visible on game screen using .enabled
            rigidbody.useGravity = true; // drop the object by setting .useGravity to true 
        }
    }
}
