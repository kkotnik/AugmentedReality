using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour{

    private Animator animator;
    public float moveDistance = 5.0f; // Distance to move forward each time
    public float rotationSpeed = 100.0f; // Speed of rotation
    public float moveSpeed = 100.0f; // Speed of continuous movement


    void Start(){
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKey(KeyCode.W)) // Press W to move forward
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S)) // Press S to move backward
        {
            MoveBackward();
        }

        if (Input.GetKey(KeyCode.A)) // Press A to turn left
        {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.D)) // Press D to rotate right
        {
            RotateRight();
        }

    }

    void MoveForward(){
        // Move the object forward by moveDistance units
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveBackward(){
        // Move the object backward by moveDistance units
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    void RotateLeft()
    {
        // Rotate left by rotationSpeed degrees per second
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    void RotateRight()
    {
        // Rotate right by rotationSpeed degrees per second
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
