using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;

    //input
    float horizontalInput;
    float verticalInput;
    bool shootInput;

    //player facing orientation
    public Transform orientation;

    //speed
    public float speed;

    public float playerHeight;
    public LayerMask ground;
    bool onGround;
    public float groundDrag;

    //bullet force
    public GameObject bullet;
    public float shootForce;


    public Transform attackPoint;
    public Camera playerCam;

    public float shootingInterval;

    bool allowInvoke = true;
    bool canShoot;

    // Start is called before the first frame update
    private void Awake()
    {
        canShoot = true;
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);


    }

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
        //movement input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //shooting input
        shootInput = Input.GetKey(KeyCode.Mouse0);
        
        if(shootInput && canShoot)
        {
            Shoot();
        }
    }

    void MovePlayer()
    {
        
        movement = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
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
        //raycasting ground
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
        //limit speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void Shoot()
    {

        canShoot = false;

        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - attackPoint.position;

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = direction.normalized;

        //bullet force
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        if (allowInvoke)
        {
            Invoke("ResetShot", shootingInterval);
            allowInvoke = false;
        }
    }

    void ResetShot()
    {
        canShoot = true;
        allowInvoke = true;
    }
}