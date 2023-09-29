using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    // NavMesh Agent
    private NavMeshAgent agent;

    // Target transform
    private Transform target;
    //public float trackingSpeed = 3.5f;
    public float attackRange = 1.5f;
    
    public float trackingDistance = 5f;

    public float health = 99;

    void Start()
    {
        // Define the agent variable to the "NavMeshAgent" component.
        agent = GetComponent<NavMeshAgent>();

        // Define the "Target" variable to the Transform variable of the object with the "Player" tag in the scene.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void FixedUpdate()
    {
        // Empty FixedUpdate function
    }
    
    void Update()
    {
        Death();
        
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            
            if (distance > attackRange)
            {
                if (distance < trackingDistance)
                {
                    Chase();
                }
                else
                {
                    StopChasing();
                }
            }
        }
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    void StopChasing()
    {
        agent.isStopped = true;
    }

    void Death()
    {
        //health = Mathf.Clamp(health, 0, 99);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            health -= 33;
        }
    }
}
