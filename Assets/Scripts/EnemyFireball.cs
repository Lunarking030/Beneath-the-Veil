using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    public float fireballSpeed = 10f;
    public float fireRate = 1f;
    public float nextFireTime;
    public float fireballLifetime = 3f;
    public int damageAmount = 10;

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

                // rotate the fireball spawn point to face the player
                fireballSpawnPoint.LookAt(player.position);

                GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);

                fireball.GetComponent<Rigidbody>().velocity = fireballSpawnPoint.forward * fireballSpeed;

                Destroy(fireball, fireballLifetime);

                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            Destroy(other.gameObject);
            // Apply damage to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        else if (other.CompareTag("Player"))
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
