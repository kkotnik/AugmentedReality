using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour{

    public GameObject player;
    private Vector3 offset; //vektor3 je za xyz movement (kok je razlika med njima)

    // Start is called before the first frame update
    void Start(){
        offset= transform.position-player.transform.position;
    }

    // Update is called once per frame
    //more se zgodit zadnja v frame loadu
    void LateUpdate(){
        // Calculate the new position based on player's position and the offset
        Vector3 newPosition = player.transform.position + offset;
        // Update the camera's position
        transform.position = newPosition;

        // Make the camera look at the player
        transform.LookAt(player.transform);
    }
}
