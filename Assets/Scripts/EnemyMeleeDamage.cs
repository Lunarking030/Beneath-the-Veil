using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour
{
    public int damageAmount = 10;  // The amount of damage the enemy deals

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Check if the object is the player
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);  // Call the TakeDamage function on the player
        }
    }
}