using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour
{
    public int damagePerTick = 1; // The amount of damage to deal to the player per tick
    public float timeBetweenTicks = 1f; // The time in seconds between each damage tick

    private float timer = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is the player
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null) // Check if the player has a PlayerHealth component
            {
                timer += Time.deltaTime;

                if (timer >= timeBetweenTicks) // Check if enough time has passed to deal damage
                {
                    playerHealth.TakeDamage(damagePerTick); // Deal damage
                    timer = 0f; // Reset timer
                }
            }
        }
    }
}
