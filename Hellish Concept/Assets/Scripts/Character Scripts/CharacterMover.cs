using UnityEngine;

//[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(0, jumpForce, 0);
            //transform.Translate(0, jumpForce * Time.deltaTime * 5000, 0);
  
        }

    }

    private void FixedUpdate()
    {



        //Setting Spawn Points
        if (timer <= 0 && rb.velocity.y == 0)
        {
            FallRespawn.value = transform.position;
            timer = 2 * Time.deltaTime;
            
        }

        if (timer > 0) timer -= 1 * Time.deltaTime;

        //Setting Fall Respawn Condition
        if (transform.position.y < -45)
        {
            transform.position = FallRespawn.value;
            
        }
    }

}

