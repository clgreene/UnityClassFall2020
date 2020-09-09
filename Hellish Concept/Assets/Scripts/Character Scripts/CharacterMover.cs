using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 movement;
    public float moveSpeed, gravity = -7.0f, rotateSpeed = 100f, jumpForce = 100;
    private float yVar;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        //turning on and off sprinting
        if (Input.GetKey("left shift"))
        {
            moveSpeed = 9;
        }

        else moveSpeed = 5;

        //declaring input variables for controls, then assigning controls to movement and rotation
        var vInput = Input.GetAxis("Vertical") * moveSpeed;
        var hInput = Input.GetAxis("Horizontal") * moveSpeed;

        movement.Set(hInput, yVar, vInput);
        
        //rotating mesh collider with mesh
        movement = transform.TransformDirection(movement);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            yVar = jumpForce;
        }

        

        controller.Move(movement * Time.deltaTime);
    }
}

