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

    Vector3 moveDirection;

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

    void PlayerInput()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalspeed * Time.deltaTime * verticalinput);
        transform.Translate(Vector3.right * horizontalspeed * Time.deltaTime * horizontalinput);

    }
}
