using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireballSpeed = 10f;
    public float fireRate = 1f;
    public float nextFireTime;
    public float fireballLifetime = 3f;

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
                Vector3 direction = (player.position - fireballSpawnPoint.position).normalized;

                GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);

                fireball.GetComponent<Rigidbody>().velocity = direction * fireballSpeed;

                Destroy(fireball, fireballLifetime);

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