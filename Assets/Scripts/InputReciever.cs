using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciever : MonoBehaviour
{

    public HandTrigger HandTrigger;

    private GrabableObject currentGrabObject = null;
    private Vector3 PositionDifferenceOnGrab;
    private Vector3 RotationDifferenceOnGrab;

    private void Awake()
    {
        PlayerInput.onTriggerDown += TriggerDown;
        PlayerInput.onTriggerUp += TriggerUp;
    }



    private void Update()
    {
        if (currentGrabObject) GrabedObjectLogic();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) TriggerDown();
        else if (Input.GetKeyUp(KeyCode.Space)) TriggerUp();
#endif
    }

    private void GrabedObjectLogic()
    {
        currentGrabObject.transform.position = HandTrigger.transform.position - PositionDifferenceOnGrab;
        currentGrabObject.transform.rotation = HandTrigger.transform.rotation;
    }

    private void TriggerDown()
    {
        if (!HandTrigger.CurrentTouchingObject) return;
        currentGrabObject = HandTrigger.CurrentTouchingObject;
        currentGrabObject.Grabbed();
        PositionDifferenceOnGrab = HandTrigger.transform.position - currentGrabObject.transform.position;
    }

    private void TriggerUp()
    {
        if (currentGrabObject) currentGrabObject.Released();
        currentGrabObject = null;
    }

}
