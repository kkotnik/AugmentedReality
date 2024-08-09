using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject player;
    public float distanceBehind = 10.0f;
    public float heightAbove = 5.0f;

    private Vector3 offset;

    void Start(){

        offset = new Vector3(0, heightAbove, -distanceBehind); //Vector3(x,y,z)

    }

    void Update()
    {

        Vector3 newPosition = player.transform.position + player.transform.rotation * offset;
        
        transform.position = newPosition; //pozicija
        transform.LookAt(player.transform.position); //rotacija
    }
}