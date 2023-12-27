using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //float speed;

    //public Transform orientation;

    float horizontalinput;
    float verticalinput;

    public Transform orientation;

    public float speed;

    Rigidbody rb;

    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
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
        rb.velocity = new Vector3(movement.x * speed, 0, movement.z * speed);

        // kalo mau pake speed++
        rb.AddForce(movement.normalized * speed *10f, ForceMode.Force);




        //rb.velocity = transform.TransformDirection(movement);
        //transform.Translate(movement * speed);

        //rb.MovePosition(movement);


    }
}
