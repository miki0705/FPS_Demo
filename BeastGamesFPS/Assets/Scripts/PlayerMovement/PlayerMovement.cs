using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField, Tooltip("Prêdkoœæ poruszania siê gracza.")]
    private float movementSpeed = 5f;
    [SerializeField, Tooltip("Moc skoku gracza.")]
    private float jumpHeight = 2;
    [SerializeField, Tooltip("Jak 'mocniej' dzia³a grawitacja przy spadaniu.")]     //¯eby skakanie by³o bardziej "growe"
    private float fallMiltiplyer = 1;


    private bool grounded;
    private Vector3 gravity;
    private Vector3 moveDirection = Vector3.zero;


    private Vector3 _velocity;

    


    private void Start()
    {
        gravity = Physics.gravity;
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
         grounded = GroundCheck();

        _velocity = Vector3.Scale(_velocity, Vector3.up);
        if (_velocity.y < 0)
        {
            if (grounded)
                _velocity.y = 0;
            else
                _velocity += gravity * (fallMiltiplyer - 1) * 0.1f;
        }
        if(!grounded)
            _velocity += gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            _velocity += JumpVec();
        _velocity += MoveVector();
        
        controller.Move(_velocity * Time.deltaTime);
    }


    /// <summary>
    /// Podaje wektor kierunkowy, nie unormowany celowo, chodzi siê szybciej po przek¹tnej.
    /// </summary>
    /// <returns>Wektor kierunkowy.</returns>
    private Vector3 MoveVector()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        dir *= movementSpeed;
        return transform.TransformDirection(dir);
    }

    /// <summary>
    /// Podaje wektor skoku, dostosowany do zmiany kierunku grawitacji.
    /// </summary>
    /// <returns>Zwraca wektor skoku, przeciwny do wektora grawitacji</returns>
    private Vector3 JumpVec()
    {
        Vector3 vec = -gravity.normalized * jumpHeight;
        return vec;
    }
    
    private bool GroundCheck()
    {
        return Physics.CheckSphere(transform.position + Vector3.down * 0.7f, 0.4f, groundMask);
    }
}
