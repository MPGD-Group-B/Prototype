using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float forwardSpeed;
    public float rightSpeed;
    public float jumpSpeed;
    public float gravity;
    public float sprintMagnification;
    private bool isSprint;
    public float crochMagnification;
    private bool isCroch;
    private float magnification;
    private Vector2 moveValue;
    private float verticalVelocity;
    private Vector3 horizontalVelocity;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
        if(moveValue.y < 0)
        {
            moveValue = moveValue / 2;
        }
    }

    void OnJump(InputValue value)
    {
        if(controller.isGrounded)
        {
            verticalVelocity = jumpSpeed;
            controller.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }
        isCroch = false;
    }

    void OnSprint(InputValue value)
    {
        isSprint = !isSprint;
        if(isSprint)
        {
            isCroch = false;
        }
    }

    void OnCroch(InputValue value)
    {
        isCroch = !isCroch;
        if(isCroch)
        {
            isSprint = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        magnification = 1;
        isCroch = false;
        isSprint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isCroch)
        {
            magnification = crochMagnification;
            controller.height = 1;
        }
        else
        {
            controller.height = 2;
        }
        if(isSprint)
        {
            magnification = sprintMagnification;
        }
        if(controller.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 movement = right * moveValue.x * rightSpeed+ forward * moveValue.y * forwardSpeed;
            controller.SimpleMove(movement * magnification);
            magnification = 1;
            horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            if (horizontalVelocity == Vector3.zero)
            {
                isSprint = false;
            }
        }
        else
        {
            verticalVelocity -= gravity;
            controller.Move(horizontalVelocity * Time.deltaTime + Vector3.up * verticalVelocity * Time.deltaTime);
        }
    }
}
