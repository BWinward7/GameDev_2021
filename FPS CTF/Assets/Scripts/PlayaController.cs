using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaController : MonoBehaviour
{
    //Movement Var
    public float moveSpeed;
    public float jumpForce;

    //Camera Var
    public float lookSens;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    private Camera camera;
    private Rigidbody rigidbody;

    //Weapon
    private PlayaWeapon weapon;

    void Awake() 
    {
        //Components
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        weapon = GetComponent<PlayaWeapon>();
        //Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        Move();
        CameraLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
        if(Input.GetButton("Fire1")) {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }

    void Move() 
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        //Face Camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //Jump Direction
        dir.y = rigidbody.velocity.y;
        //Move
        rigidbody.velocity = dir;
    }

    void Jump() 
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSens;
        rotX += Input.GetAxis("Mouse Y") * lookSens;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //Apply rotation to camera
        camera.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
        
    }
}
