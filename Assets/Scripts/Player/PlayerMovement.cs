using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5;

    [Header("Ground Check")] 
    [SerializeField] private float radiusSphere = 0.5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject spherePos;
    private bool isGrounded = true;
    public float groundDrag;
    
    
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    
    [SerializeField] private Transform orientation;

    public enum State
    {
        _idle,
        _walking,
        _falling,
        _landing,
        _running
        
    }
    
    [SerializeField] private State currentState = State._idle;
    
    private void Start()
    {
        State currentState = State._idle;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        CheckState();
        CheckIsGrounded();
        CheckInput();
        
        switch (currentState)
        {
            case State._idle:
                IsIdling();
                break;
            case State._walking:
                IsWalking();
                break;
            case State._falling:
                IsFalling();
                break;
            case State._landing:
                IsLanding();
                break;
            case State._running:
                IsRunning();
                break;
        }
    }

    private void CheckInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        CheckIsGrounded();
    }
    
    private bool isLanded = false;
    

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
        {
            transform.position += moveDirection.normalized * walkSpeed * Time.deltaTime; 
        }
    }
    
    private void CheckIsGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics.OverlapSphere(spherePos.transform.position, radiusSphere,groundLayer).Length > 0;

        isLanded = !wasGrounded && isGrounded;

        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    
    private void CheckState()
    {
        if (!isGrounded)
        {
            currentState = State._falling;
        }
        else
        {
            if (isLanded)
            {
                currentState = State._landing;
            }
            else if (horizontalInput != 0 || verticalInput != 0)
            {
                currentState = Input.GetKey(KeyCode.LeftShift) ? State._running : State._walking;
            }
            else
            {
                currentState = State._idle;
            }
        }
    }
    
    private void IsWalking()
    {
        MovePlayer();
    }

    private void IsIdling()
    {
        
    }

    private void IsFalling()
    {
        MovePlayer();
    }

    private void IsLanding()
    {
        
    }
    private void IsRunning()
    {
        Debug.Log(currentState);
        MovePlayer();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,radiusSphere);
    }
}
