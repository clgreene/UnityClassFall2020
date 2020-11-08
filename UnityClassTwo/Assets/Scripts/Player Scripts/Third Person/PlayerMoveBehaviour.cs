using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Making sure player object has a Unity Character Controller
[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    //Setting movement variables
    private CharacterController controller;
    private Vector3 movement;
    public int jumpCountMax = 2;
    public int jumpCount = 0;
    public float gravity = -7.0f, rotateSpeed = 100f, jumpForce = 6;
    private float yVar;

    public Animator animator;

    //Setting Scriptable Floats
    public FloatData moveSpeed, normalSpeed, sprintSpeed;

    //Setting Scriptable Integers
    public IntData playerJumpCount, healthInt;

    //Setting Scriptable Vector3's
    public Vector3Data currentSpawnPoint;

    //Setting health string and integers
    public Text healthText;

    private void Start()
    {
        //pulling in characters built in character controller
        controller = GetComponent<CharacterController>();
        healthInt.value = 100;
    }

    // Update is called once per frame
    private void Update()
    {
        

        //Defining Sprint State
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }

        else moveSpeed = normalSpeed;

        //declaring input variables for controls, then assigning controls to movement and rotation
        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        var hInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        animator.SetFloat("walkSpeed", vInput);

        movement.Set(vInput, yVar, 0);
        transform.Rotate(0, hInput, 0);

        //rotating mesh collider with mesh
        movement = transform.TransformDirection(movement);

        //Setting gravity
        yVar += gravity * Time.deltaTime;

        //Defining jump counts for double jumping
        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        //giving controller defined movement
        controller.Move(movement * Time.deltaTime);

        //setting health int to text
        healthText.text = healthInt.value.ToString("0");
    }



    private void OnEnable()
    {
        //set position of player to last checkpoint reached
        transform.position = currentSpawnPoint.value;
    }
}
