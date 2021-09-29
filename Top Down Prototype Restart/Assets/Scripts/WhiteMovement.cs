using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 5.0f;
    public float hInput;
    public float vInput;

    public float xRange = 11.0f;
    public float yRange = 6.5f;
    
    public GameObject projectile;
    public Vector3 offset = new Vector3(0,0,0);
    // Update is called once per frame
    void Update()
    {
        // Gather Keyboard input
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes White move left and right
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
        // Makes White move up and down
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        //Right Wall
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Left Wall
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Top Wall
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        //Bottom Wall
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + offset, projectile.transform.rotation);
        }
    }    
}
