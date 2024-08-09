using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour{

    private Animator animator;
    public float moveDistance = 5.0f; // distance to move forward each time
    public float rotationSpeed = 100.0f; // speed of rotation
    public float moveSpeed = 5.0f; // speed of continuous movement


    void Start(){

        animator = GetComponent<Animator>();
        
    }

    
    void Update(){

        if (Input.GetKey(KeyCode.W)){
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S)){
            MoveBackward();
        }

        if (Input.GetKey(KeyCode.A)){
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.D)){
            RotateRight();
        }

    }

    void MoveForward(){
        // move by moveDistance units
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveBackward(){
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    void RotateLeft(){
        // Rotate(Vector3 eulers, Space relativeTo = Space.Self);
        // rotationSpeed degrees per second
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    void RotateRight(){
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
