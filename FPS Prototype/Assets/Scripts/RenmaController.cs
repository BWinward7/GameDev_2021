using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenmaController : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    //Camera
    public float lookSensitivity; //Mouse look sensitivity
    public float maxLookX; //Lowest Down Looking Posisiton
    public float minLookX; //Highest Up Looking Position
    private float rotX; //Current X rotation of the camera
    private Camera caam;
    private Rigidbody rb;


    void Awake() 
    {
        //Get the componenets
        caam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX = Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //Apply rotation to camera
        caam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        caam.transform.eulerAngles += Vector3.up * y;
    }
}
