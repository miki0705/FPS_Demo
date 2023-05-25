using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion initialRotation;
    [Header("Rotation")]
    [SerializeField]
    private float rotationAmount;
    [SerializeField]
    private float maxRotationAmount;

    [SerializeField]
    private float smoothAmount;

    [Header("Freeze")]
    [SerializeField]
    private bool axisX = false;
    [SerializeField]
    private bool axisY = false;
    [SerializeField]
    private bool axisZ = false;

    private void Start()
    {
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        Tilt();
    }

    private void Tilt()
    {

        float tiltY = Mathf.Clamp(Input.GetAxis("Mouse X") * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float tiltX = Mathf.Clamp(Input.GetAxis("Mouse Y") * rotationAmount, -maxRotationAmount, maxRotationAmount);
        Quaternion finalRotation = Quaternion.Euler(new Vector3(
            !axisX ? -tiltX : 0f, 
            !axisY ? tiltY : 0f, 
            !axisZ ? 0 : 0f));
                                                                                                  
        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothAmount);
    }
}
