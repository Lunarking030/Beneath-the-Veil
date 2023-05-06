using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 10f;
    public float fireRate = 1f;
    public float nextFireTime;
    public float arrowLifetime = 3f;

    private Transform player;
    private bool inRange; // variable to check if the player is in attack range

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (inRange)
        {
            if (Time.time >= nextFireTime)
            {
                Vector3 direction = (player.position - arrowSpawnPoint.position).normalized;

                // rotate the arrow spawn point to face the player
                arrowSpawnPoint.LookAt(player.position);

                GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);

                arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;

                Destroy(arrow, arrowLifetime);

                nextFireTime = Time.time + fireRate;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}