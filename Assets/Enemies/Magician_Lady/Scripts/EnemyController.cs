using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float chaseRange = 10f;
    public float attackRange = 1f;
    public float attackDelay = 2f;

    private Animator animator;
    private bool isPatrolling = true;
    private bool isChasing = false;
    private bool isAttacking = false;
    private Vector3 patrolTarget;
    private float lastAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Set initial patrol target
        patrolTarget = transform.position;
    }

    void Update()
    {
        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is within chase range
        if (distanceToPlayer <= chaseRange)
        {
            isPatrolling = false;
            isChasing = true;
            isAttacking = false;

            // Update patrol target to player's position
            patrolTarget = player.position;
        }

        // Check if player is within attack range
        if (distanceToPlayer <= attackRange)
        {
            isPatrolling = false;
            isChasing = false;
            isAttacking = true;

            // Attack player if attack delay has passed since last attack
            if (Time.time - lastAttackTime >= attackDelay)
            {
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time;
            }
        }
        else
        {
            isAttacking = false;
        }

        // Patrol if not chasing or attacking
        if (isPatrolling)
        {
            if (Vector3.Distance(transform.position, patrolTarget) < 0.5f)
            {
                // Generate new patrol target
                patrolTarget = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            }

            // Move towards patrol target
            Vector3 direction = (patrolTarget - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            // Set walk animation
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
        }
        else
        {
            // Set idle animation
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        // Chase player if within chase range
        if (isChasing)
        {
            // Move towards player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            // Set run animation
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
        }
    }
}

