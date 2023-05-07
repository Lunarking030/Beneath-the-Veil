using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private Transform player;
    private NavMeshAgent agent;
    public float enemyDistance = 0.7f;
    public LayerMask obstacleLayer; // Layer mask for obstacles

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Disable NavMeshAgent rotation so we can control it ourselves
    }

    void Update()
    {
        // Look at the player
        transform.LookAt(player);

        // Set the NavMeshAgent's destination
        agent.SetDestination(player.transform.position);

        // Check if the player is within attacking distance
        if (Vector3.Distance(transform.position, player.position) < enemyDistance)
        {
            agent.velocity = Vector3.zero;
            GetComponent<Animator>().Play("Attack");
        }

        // Check for obstacles in front of the enemy and move around them
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, agent.radius, obstacleLayer))
        {
            // Calculate a new destination to move around the obstacle
            Vector3 newDestination = transform.position + transform.right * 3f;
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(newDestination, out navHit, 5f, NavMesh.AllAreas))
            {
                agent.SetDestination(navHit.position);
            }
        }

        // Update the enemy's rotation to face its movement direction
        if (agent.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
    }
}

