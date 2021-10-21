using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileStart;
    public float projectileSpeed;

    public int currentAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float attackSpeed;
    private float lastAttackTime;
    private bool isPlayer;

    // Update is called once per frame
    void Update()
    {
        // are we attached to the player
        if(GetComponent<PlayaController>())
        {
            isPlayer = true;
        }
    }
    public bool CanShoot()
    {
        if(Time.time - lastAttackTime >= attackSpeed)
        {
            if(currentAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }
    public void Shoot()
    {
        lastAttackTime = Time.time;
        currentAmmo--;
        GameObject bullet = Instantiate(projectilePrefab, projectileStart.position, projectileStart.rotation);
        //set the velocity
        bullet.GetComponent<Rigidbody>().velocity = projectileStart.forward * projectileSpeed;
    }
}
