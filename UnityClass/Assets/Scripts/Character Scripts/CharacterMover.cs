using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 movement;
    public int jumpCountMax = 2;
    public int jumpCount = 0;
    public float gravity = -7.0f, rotateSpeed = 100f, jumpForce = 500;
    private float yVar;

    public FloatData moveSpeed, normalSpeed, sprintSpeed;

    public IntData playerJumpCount;

    public Vector3Data currentSpawnPoint;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Defining Sprint State
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
        
        //declaring input variables for controls, then assigning controls to movement and rotation
        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        var hInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        movement.Set(vInput, yVar, 0);
        transform.Rotate(0, hInput, 0);

        //rotating mesh collider with mesh
        movement = transform.TransformDirection(movement);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y <0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        controller.Move(movement * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //set location data of player to the current Spawn Point
    }

    private void OnEnable()
    {
        //set position of player to the location data of the player
    }
}
