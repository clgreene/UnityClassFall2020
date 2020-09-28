using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{

    public float moveSpeed, gravity = -7.0f, jumpForce = 100;

    private float timer = 2;
    private Rigidbody rb;

    public VectorThreeData FallRespawn;
    public BoolData dialogue;

    private void Start()
    {
        //getting parent componenets RigidBody component
        rb = GetComponent<Rigidbody>();
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

        //pausing movement while dialogue is active
        if (dialogue.value == false) 
        {
            //declaring input variables for controls, then assigning controls to movement and rotation
            if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A)) transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D)) transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        

    }

    private void FixedUpdate()
    {
        //Setting Spawn Points
        if (timer <= 0 && rb.velocity.y == 0)
        {
            FallRespawn.value = transform.position;
            timer = 2;
            
        }

        if (timer > 0) timer -= 1 * Time.deltaTime;

        //Setting Fall Respawn Condition
        if (transform.position.y < -15)
        {
            transform.position = FallRespawn.value;
            
        }
    }

}

