using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject projectile;
    public Transform player;
    public float xRange = 11.0f;
    public float yRange = 6.5f;
    public string direction;
    public float hInput;
    public float vInput;

    void Start() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if(hInput < 0)
        {
            direction = "Left";
        }
        else if(hInput > 0)
        {
            direction = "Right";
        }
        else if(vInput < 0)
        {
            direction = "Down";
        }
        else if(vInput > 0)
        {
            direction = "Up";
        }
        else
        {
            direction = "Up";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "Right")
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(direction == "Left")
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(direction == "Down")
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if(direction == "Up")
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
        //Left Wall
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
        //Top Wall
        if (transform.position.y > yRange)
        {
            Destroy(gameObject);
        }
        //Bottom Wall
        if (transform.position.y < -yRange)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {     
        if(other.gameObject.CompareTag("Player"))
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
