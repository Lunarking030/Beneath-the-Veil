using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour
{
    public int damageAmount = 10;  // The amount of damage the enemy deals

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the object is the player
        {
            other.GetComponent<Player>().TakeDamage(damageAmount);  // Call the TakeDamage function on the player
        }
    }
}


