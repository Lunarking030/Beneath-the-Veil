using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour
{
    public int damagePerSecond = 10; // The amount of damage to deal to the player per second

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is the player
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null) // Check if the player has a PlayerHealth component
            {
                playerHealth.TakeDamage((int)(damagePerSecond * Time.deltaTime)); // Deal damage over time based on delta time
            }
        }
    }
}
