using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public Transform player;
    public float xRange = 11.0f;
    public float yRange = 6.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
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

}
