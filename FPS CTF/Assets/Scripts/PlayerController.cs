using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    public float jumpForce;
    //Variables for moded move
    public float hInput;
    public float vInput;
    
    //Camera
    public float lookSensitivity; //Mouse look sensitivity
    public float maxLookX; //Lowest Down Looking Posisiton
    public float minLookX; //Highest Up Looking Position
    private float rotX; //Current X rotation of the camera
    private Camera camera;
    private Rigidbody rb;
    
    private Weapon weapon;

    void Awake() 
    {
        //Get the componenets
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();

        if(Input.GetButtonDown("Jump"))
            Jump();

        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }

    void Move()
    {
        /*
        //This code makes my "W" key always move me to where I'm looking
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes White move left and right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * hInput);
        // Makes White move up and down
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vInput);
        */
        //Original Code
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        //rb.velocity = new Vector3(x, rb.velocity.y, z);
        //Face the direction of the Camera;
        Vector3 dir = transform.right * x + transform.forward * z;
        //Jump direction
        dir.y = rb.velocity.y;
        //Move
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //Apply rotation to camera
        camera.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
        
    }
}
