﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    private bool patrolling = true;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public ZombieData data;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < data.lockRange)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < data.attackRange)
            {
                agent.SetDestination(this.transform.position);
                LookAtPlayer();
                Debug.Log("Attacl");
            }
            else
            {
                MoveToPlayer();
            }
        }
        else 
        {
            //Debug.Log(waypoints.Length);
            agent.SetDestination(waypoints[currentWaypoint].position);
            if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].position) < 30.0f) 
            {
                if (currentWaypoint < waypoints.Length - 1)
                {
                    ++currentWaypoint;
                }
                else
                {
                    currentWaypoint = 0;
                }
            }
        }
    }

    void MoveToPlayer() 
    {
        agent.SetDestination((this.transform.position + player.transform.position) /2.0f);
    }
    void LookAtPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * data.rotSpeed);   
    }
}