using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class AcidSpitter : MonoBehaviour
{
    public GameObject acidballPrefab;
    public Transform acidballSpawnPoint;
    public float acidballSpeed = 10f;
    public float fireRate = 1f;
    public float nextFireTime;
    public float acidballLifetime = 3f;
    public float attackRange = 10f; // the range at which the AcidSpitter can attack the player

    private Transform player;
    private bool inRange; // variable to check if the player is in attack range

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (inRange && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (Time.time >= nextFireTime)
            {
                Vector3 direction = (player.position - acidballSpawnPoint.position).normalized;

                GameObject acidball = Instantiate(acidballPrefab, acidballSpawnPoint.position, Quaternion.identity);

                acidball.GetComponent<Rigidbody>().velocity = direction * acidballSpeed;

                Destroy(acidball, acidballLifetime);

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Acid collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null && !playerHealth.isTakingAcidDamage)
            {
                playerHealth.TakeAcidDamage();
            }
        }
    }
}
