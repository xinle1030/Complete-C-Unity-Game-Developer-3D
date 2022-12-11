using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attache to Player(Dodgy)
public class Scorer : MonoBehaviour
{
    int hits = 0;

    // keep track of number of collisions of Player
    private void OnCollisionEnter(Collision other) 
    {
        // only increment the score if the Player is first time bounced into the obstacle
        if(other.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("You've bumped into a thing this many times: " + hits);
        }
    }
}
