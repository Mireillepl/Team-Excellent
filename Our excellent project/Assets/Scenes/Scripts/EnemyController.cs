using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    private bool patrolling = true;
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }
        if (patrolling) 
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
}