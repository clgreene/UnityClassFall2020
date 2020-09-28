using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{

    private CharacterController controller;
    public float moveSpeed, gravity = -7.0f, jumpForce = 100;

    public Rigidbody rb;

    public VectorThreeData FallRespawn;

    private void Start()
    {
        
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
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        
    }

    private void FixedUpdate()
    {
        //Setting Spawn Points
        if (controller.isGrounded == true)
        {
            FallRespawn.value = transform.position;
            
        }

        //Setting Respawn Condition
        if (transform.position.y < -15)
        {
            transform.position = FallRespawn.value;
            
        }
    }

}

