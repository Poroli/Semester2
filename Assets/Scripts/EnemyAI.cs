using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform enemyGFX;
    public Playerhealth P_Health;
    public ValueScript V_Script;
    public Animator catAnimation;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public bool playerrechable = false;

    public bool catAttack = false;
    



    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        P_Health = FindObjectOfType<Playerhealth>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }
    void UpdatePath()
    { 
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerrechable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerrechable = false;
        }
    }

    public void AttackPlayer()
    {
        P_Health.currenthealth -= V_Script.NormalEnemyDMG;
    }


    void FixedUpdate()
    {
        if (playerrechable == true)
        {
            Debug.Log("Attack Player");
            catAnimation.SetTrigger("Attack");          
        }
        else
        {
            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            { 
                reachedEndOfPath=false;
            }

            Vector2 direcion = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direcion * speed * Time.deltaTime;
            rb.AddForce(transform.right * force);
            force.y = rb.velocity.y;

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            if (force.x >= 0.01f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (force.x <= -0.01f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        }      
    }
}
