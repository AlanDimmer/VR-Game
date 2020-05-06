using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour
{

    public float rotateSpeed;
    public float holdTime;
    public float rotateTime;

    private bool isRotating = false;
    private bool startRotating = false;
    [SerializeField]
    private float timer = 0;
    [SerializeField]
    Vector3 randomDirection = Vector3.zero;

    private void Update()
    {
        RotateLight();
    }

    private void RotateLight()
    {
        if (!isRotating)
        {
            randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            isRotating = true;
            timer = 0;
        }
        Vector3 tempRotation = transform.localEulerAngles;
        tempRotation += randomDirection * rotateSpeed * Time.deltaTime;
        if (tempRotation.x > 150 || tempRotation.x < 30)
        {
            Debug.Log("Changing direction: " + tempRotation.x);
            randomDirection *= -1;
            if (tempRotation.x < 300 && tempRotation.x > 30) tempRotation.x = 150;
            else tempRotation.x = 30;
            timer = 0;
        }
        else if (Mathf.Approximately((int)tempRotation.x, 90))
        {
            randomDirection *= -1;
        }
        if (timer > rotateTime) isRotating = false;
        timer += Time.deltaTime;
        if (isRotating) transform.localEulerAngles = tempRotation;
    }


}
