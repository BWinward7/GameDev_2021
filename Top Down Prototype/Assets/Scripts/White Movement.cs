using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hInput;
    public float vInput;

    public float xRange = 10.0f;
    public float yRange = 5.0f;
  
    // Update is called once per frame
    void Update()
    {
        // Gather Keyboard input
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes White move left and right
        transform.Rotate(Vector3.right * speed * Time.deltaTime * hInput);
        // Makes White move up and down
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
        //Right Wall
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Left Wall
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Top Wall
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        //Bottom Wall
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
    }
}
