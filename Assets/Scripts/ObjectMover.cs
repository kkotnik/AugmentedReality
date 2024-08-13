using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour{

    private Animator animator;
    public float moveDistance = 5.0f; // distance to move forward each time
    public float rotationSpeed = 100.0f; // speed of rotation
    public float moveSpeed = 5.0f; // speed of continuous movement

    //BUTTONS
    public Button buttonForward;
    public Button buttonBackward;
    public Button buttonLeft;
    public Button buttonRight;

    //ali so gumbi aktivni ?
     private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    void Start(){
        //AddEventTrigger(GameObject obj, EventTriggerType type, System.Action<BaseEventData> action)
        AddEventTrigger(buttonForward.gameObject, EventTriggerType.PointerDown, (data) => { isMovingForward = true; });
        AddEventTrigger(buttonForward.gameObject, EventTriggerType.PointerUp, (data) => { isMovingForward = false; });

        AddEventTrigger(buttonBackward.gameObject, EventTriggerType.PointerDown, (data) => { isMovingBackward = true; });
        AddEventTrigger(buttonBackward.gameObject, EventTriggerType.PointerUp, (data) => { isMovingBackward = false; });

        AddEventTrigger(buttonLeft.gameObject, EventTriggerType.PointerDown, (data) => { isRotatingLeft = true; });
        AddEventTrigger(buttonLeft.gameObject, EventTriggerType.PointerUp, (data) => { isRotatingLeft = false; });

        AddEventTrigger(buttonRight.gameObject, EventTriggerType.PointerDown, (data) => { isRotatingRight = true; });
        AddEventTrigger(buttonRight.gameObject, EventTriggerType.PointerUp, (data) => { isRotatingRight = false; });
    }

    void Update()
    {
        if (isMovingForward){
            MoveForward();
        }
        if (isMovingBackward){
            MoveBackward();
        }
        if (isRotatingLeft){
            RotateLeft();
        }
        if (isRotatingRight){
            RotateRight();
        }
    }

    void MoveForward(){
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveBackward(){
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    void RotateLeft(){
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    void RotateRight(){
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // Helper method to add event triggers - kode nisem napisala sama, jo razumem
    private void AddEventTrigger(GameObject obj, EventTriggerType type, System.Action<BaseEventData> action){
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        //doda eventtrigger ce ga objekt se nima
        if (trigger == null){
            trigger = obj.AddComponent<EventTrigger>();
        }

        //entry pove kdaj se zacne event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;

        //dodamo listenerja na entry
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(action));
        
        //dodamo entry na trigger
        trigger.triggers.Add(entry);
    }


}
