using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{

    public GrabableObject CurrentTouchingObject;

    private void OnTriggerEnter(Collider other)
    {
        GrabableObject grabableObject = other.GetComponent<GrabableObject>();
        if (!grabableObject) return;
        if (!CurrentTouchingObject) CurrentTouchingObject = grabableObject;
        else
        {
            if (Vector3.Distance(CurrentTouchingObject.transform.position, transform.position) 
                > Vector3.Distance(grabableObject.transform.position, transform.position))
                CurrentTouchingObject = grabableObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GrabableObject grabableObject = other.GetComponent<GrabableObject>();
        if (!grabableObject) return;
        if (grabableObject == CurrentTouchingObject) CurrentTouchingObject = null;
    }

}
