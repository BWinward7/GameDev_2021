using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;
    
    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path = new List<Vector3>();
    
    private Weapon weapon;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //Gather the Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath()
    {
        //Calc path to target
        UnityEngine.AI.NavMeshPath navMeshPath = new UnityEngine.AI.NavMeshPath();
        UnityEngine.AI.NavMesh.CalculatePath(transform.position, target.transform.position, UnityEngine.AI.NavMesh.AllAreas, navMeshPath);

        //Save path as a list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count ==0)
            return;
        //Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);

    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //Look at Target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
        //Distance to Target
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange){
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        else
            ChaseTarget();
    }
}
