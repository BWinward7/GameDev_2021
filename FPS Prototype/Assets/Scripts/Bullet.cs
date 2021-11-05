using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifetime;
    private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
        void OnTriggerEnter(Collider other)
    {
        //Did we hit the targer aka player
        if(other.CompareTag("Player"))
        {
            other.GetComponent<RenmaController>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        else
            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
        //Disabe Bullet
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
