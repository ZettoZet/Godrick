using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveDummy : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform player;

    float xRotation;
    float yRotation;

    public GameObject playerCam;

    Vector3 campos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCam = GameObject.Find("PlayerCam");

    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


        //head cam
        playerCam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        campos = new Vector3(transform.position.x, player.position.y, transform.position.z);

    }


}
