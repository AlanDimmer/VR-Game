using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabableObject : MonoBehaviour
{

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Grabbed()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

    public void Released()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }

}
