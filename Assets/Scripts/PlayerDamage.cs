using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damageAmount = 10;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
        else if (collision.gameObject.CompareTag("Projectile"))
        {
            // Check if the collision is with the player
            if (collision.contacts.Length > 0 && collision.contacts[0].otherCollider.gameObject == gameObject)
            {
                TakeDamage(damageAmount);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player death here
    }
}
