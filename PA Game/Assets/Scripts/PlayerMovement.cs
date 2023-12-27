using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //float speed;

    //public Transform orientation;

    Rigidbody rb;
    Vector3 movement;

    float horizontalinput;
    float verticalinput;

    public Transform orientation;

    public float speed;

    public float playerHeight;
    public LayerMask ground;
    bool onGround;
    public float groundDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        GroundCheck();
        MaxSpeed();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        
        movement = orientation.forward * verticalinput + orientation.right * horizontalinput;
        
        // kalo mau pake speed konstan
        //rb.velocity = new Vector3(movement.x * speed, 0, movement.z * speed);

        // kalo mau pake speed++
        rb.AddForce(movement.normalized * speed * 10f, ForceMode.Force);




        //rb.velocity = transform.TransformDirection(movement);
        //transform.Translate(movement * speed);

        //rb.MovePosition(movement);
    }

    void GroundCheck()
    {
        onGround = Physics.Raycast(transform.position,Vector3.down, playerHeight * 0.945472f + 0.2f, ground);

        if (onGround)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    void MaxSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }
}