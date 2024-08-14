using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour
{
    private Animator animator;
    public float moveDistance = 5.0f; // distance to move forward each time
    public float rotationSpeed = 100.0f; // speed of rotation
    public float moveSpeed = 5.0f; // speed of continuous movement

    // BUTTONS
    public Button buttonForward;
    public Button buttonBackward;
    public Button buttonLeft;
    public Button buttonRight;

    // Are the buttons active?
    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    // Reference to the AudioManager
    private AudioManager audioManager;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();

        // Start playing the engine idle sound
        audioManager.PlayEngineSound(audioManager.Engine);

        // Set up button event triggers
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
        bool wasMoving = isMoving;
        isMoving = false;

        if (isMovingForward)
        {
            MoveForward();
            isMoving = true;
        }
        if (isMovingBackward)
        {
            MoveBackward();
            isMoving = true;
        }
        if (isRotatingLeft)
        {
            RotateLeft();
            isMoving = true;
        }
        if (isRotatingRight)
        {
            RotateRight();
            isMoving = true;
        }

        // Manage engine sound based on movement
        if (isMoving && !wasMoving)
        {
            // Object starts moving, play the engine running sound
            audioManager.PlayEngineSound(audioManager.EngineRunning);
        }
        else if (!isMoving && wasMoving)
        {
            // Object stops moving, play the idle engine sound
            audioManager.PlayEngineSound(audioManager.Engine);
        }
    }

    void MoveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveBackward()
    {
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // Helper method to add event triggers
    private void AddEventTrigger(GameObject obj, EventTriggerType type, System.Action<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        // Add EventTrigger if the object doesn't have one
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        // Create a new entry for the event trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;

        // Add the action as a listener to the entry
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(action));

        // Add the entry to the trigger's list of events
        trigger.triggers.Add(entry);
    }
}
