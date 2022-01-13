using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject teamHitParticle;

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
        GameObject obj = Instantiate(teamHitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 0.5f);

        if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
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
