using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public float lifetime;
    private float shootTime;

    public GameObject enemyHitParticle;

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
         GameObject obj = Instantiate(enemyHitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 0.2f);
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
        if(other.CompareTag("Team"))
        {
            other.GetComponent<Team>().TakeDamage(damage);
        }
        else
            gameObject.SetActive(false);
    }
    // Update is called once per frame
    //Disabe Bullet
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
