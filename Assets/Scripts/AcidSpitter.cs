using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpitter : MonoBehaviour
{
    public GameObject acidPrefab; // The prefab for the acid object
    public float spitInterval = 2f; // How often the enemy will spit acid
    public float spitForce = 10f; // How fast the acid will travel
    public float acidLifetime = 5f; // How long the acid will stay on the floor
    public float damagePerSecond = 10f; // How much damage the acid will do per second to the player

    private Transform player; // Reference to the player's transform
    private bool canSpit = false; // Whether or not the enemy can currently spit acid

    void Start()
    {
        // Find the player game object and get its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // If the enemy can spit and the AcidSpitter script is enabled, spit acid
        if (canSpit && enabled)
        {
            SpitAcid();
        }
    }

    void SpitAcid()
    {
        // Set canSpit to false to prevent the enemy from spitting again immediately
        canSpit = false;

        // Instantiate the acid object at the enemy's position
        GameObject acid = Instantiate(acidPrefab, transform.position, Quaternion.identity);

        // Calculate the direction to spit the acid (towards the player)
        Vector3 direction = (player.position - transform.position).normalized;

        // Apply force to the acid object in the calculated direction
        acid.GetComponent<Rigidbody>().AddForce(direction * spitForce, ForceMode.Impulse);

        // Destroy the acid object after a certain amount of time
        Destroy(acid, acidLifetime);

        // Start a coroutine that will allow the enemy to spit again after a certain amount of time
        StartCoroutine(SpitCooldown());
    }

    IEnumerator SpitCooldown()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(spitInterval);

        // Set canSpit back to true to allow the enemy to spit again
        canSpit = true;
    }

    void OnCollisionStay(Collision other)
    {
        // If the acid object is colliding with the player, damage them
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamagePlayer(other.gameObject.GetComponent<PlayerHealth>()));
        }
    }

    void OnCollisionExit(Collision other)
    {
        // Stop damaging the player when they are no longer touching the acid
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator DamagePlayer(PlayerHealth playerHealth)
    {
        // Continuously damage the player while they are in contact with the acid
        while (true)
        {
            playerHealth.TakeDamage((int)(damagePerSecond * Time.deltaTime));
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the enemy enters the trigger zone, enable the AcidSpitter script and set canSpit to true
        if (other.gameObject.CompareTag("Player"))
        {
            enabled = true;
            canSpit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the enemy leaves the trigger zone, disable the AcidSpitter script and set canSpit to false
        if (other.gameObject.CompareTag("Player"))
        {
            enabled = false;
            canSpit = false;
            StopAllCoroutines();
        }
    }
}