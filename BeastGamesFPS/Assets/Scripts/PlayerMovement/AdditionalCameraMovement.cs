using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalCameraMovement : MonoBehaviour
{

    private Quaternion initialRotation;
    private Quaternion startingRotation;

    private PlayerInput playerInput;
    private float tiltStartedBank = 0;
    private Vector2 inputs;

    [SerializeField]
    private float maxRotationAmountZ = 5;

    [Header("BetterTilt")]
    [SerializeField]
    private float tiltDuration = .5f;
    [SerializeField]
    private AnimationCurve tiltCurve;
    

    [Header("Freeze")]

    [SerializeField]
    private bool axisZ = false;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
            BetterHeadTilt();
    }

    private void BetterHeadTilt()
    {
        if (inputs.x != playerInput.inputAxis.x)
        {
            ResetTilt();

        }

        if (tiltStartedBank > 0)
        {
            tiltStartedBank -= Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(startingRotation, FinalRotation() * initialRotation, tiltCurve.Evaluate(1 - tiltStartedBank / tiltDuration));
        }
        else tiltStartedBank = 0;



    }


    private void ResetTilt()
    {
        tiltStartedBank = tiltDuration;
        startingRotation = transform.localRotation;
        inputs.x = playerInput.inputAxisRaw.x;
    }
    private Quaternion FinalRotation()
    {
        float tiltZ = playerInput.inputAxisRaw.x * maxRotationAmountZ;
        return Quaternion.Euler(new Vector3(0, 0, !axisZ ? -tiltZ : 0f));
    }


}
