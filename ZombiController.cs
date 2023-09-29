using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiController : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform hedef;
    //public float takipHizi = 3.5f;
    public float saldiriMesafesi = 1.5f;
    
    public float takipMesafesi = 5f;

    public float healty=99;

    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        hedef = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate() 
    {
        
    }
    void Update()
    {
        Death();
    /////////////////////////////////////////////////////////////////////////////////////
        if (hedef != null)
        {
            float mesafe = Vector3.Distance(transform.position, hedef.position);
            
            if (mesafe > saldiriMesafesi)
            {
                if (mesafe < takipMesafesi) 
                {
                    TakipEt();
                }
                else
                {
                    Durdur(); 
                    
                    
                }
            }
            
        }
    }

    void TakipEt()
    {
        agent.isStopped=false;
        agent.SetDestination(hedef.position);
    }

     void Durdur()
    {
        agent.isStopped = true;
    }

     void Death()
     {
        //healty=Mathf.Clamp(healty,0,99);
        if (healty<=0)
        {
            Destroy(this.gameObject);
        }
     }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            
            Destroy(other.gameObject);
            healty-=33;
            
        }
        
        
    }
}
