using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //AI namespace will give you access to the NavMeshAgent class

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; // enable you to assign the Nav Mesh Agent reference in the Inspector window
    public Transform[] waypoints; // array of waypoint positions
    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //set the initial destination of the Nav Mesh Agent
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            //% takes whatever is to its left and divides it by whatever is to its right, then returns the remainder
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
