using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //float speed;

    //public Transform orientation;

    float horizontalinput;
    float verticalinput;

    public float horizontalspeed;
    public float verticalspeed;

    Rigidbody rb;

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
        Vector3 movement = new Vector3(horizontalinput * horizontalspeed, 0, verticalinput * verticalspeed);

        rb.velocity = transform.TransformDirection(movement);

        //rb.AddForce(movement.normalized *10f, ForceMode.Force);
    }
}
