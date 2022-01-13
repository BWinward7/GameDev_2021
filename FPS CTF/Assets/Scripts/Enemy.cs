using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

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

    private List<Vector3> path;
    
    private Weapon weapon;
    private GameObject target;
    private GameObject player;
    public Transform closestTeam;
    private GameObject rteam;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        //Gather the Components
        weapon = GetComponent<Weapon>();
        player = FindObjectOfType<PlayerController>().gameObject;
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath()
    {
        //Calc path to target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

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
        //Death Animation
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.back*10, ForceMode.Impulse);
        rb.AddForce(Vector3.up*5, ForceMode.Impulse);

        GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
    // Update is called once per frame
    public Transform GetClosestTeam()
        {
            GameObject[] team = GameObject.FindGameObjectsWithTag("Team");
            float closestDistance = Mathf.Infinity;
            Transform trans = null;

            foreach (GameObject go in team)
            {
                float currentDistance;
                currentDistance = Vector3.Distance(transform.position, go.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    trans = go.transform;
                }
                rteam = go;
            }
            return trans;
        }
    void ChooseTarget(Transform trans)
    {
        float pdist = Vector3.Distance(transform.position, player.transform.position);
        float tdist = Vector3.Distance(transform.position, trans.position);
        if(pdist <= tdist + 10)
            target = player;
        else if(pdist <=30)
            target=player;
        else if(tdist <=30 && tdist > 0)
            target = rteam;
        //else
            //Patrol();
    }
    void Update()
    {
        closestTeam = GetClosestTeam();
        ChooseTarget(closestTeam);
        //Look at Target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
        
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist <= attackRange){
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        else
            ChaseTarget();
       
    }
}
