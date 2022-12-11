using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // SerializeField makes the variable to be accessible and modifiable from Unity Screen
    [SerializeField] float moveSpeed = 10f; // move speed scale factor
    
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update() 
    {
        MovePlayer();
    }

    void PrintInstructions() 
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {

        // Input.GetAxis("Horizontal") return value along x-axis when user press left or right key
        // here we are moving the object when the key is pressed by the user as input 

        // Use Time.deltaTime tells us how long each frame took to execute
        // when we multiple smt by Time.deltaTime, it makes our game "frame rate independent"
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // accessing the transform of the game object
        // - translate to add to x, y,
        // - accept arguments of type floating point, exp 0.1f and not 0.1
        transform.Translate(xValue,0,zValue);
    }

}
