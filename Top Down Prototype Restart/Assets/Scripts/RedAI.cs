using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : MonoBehaviour
{
    public Transform white;
    public float moveSpeed = 2.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = white.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
