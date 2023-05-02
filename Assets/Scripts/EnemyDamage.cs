using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Dealing " + damageAmount + " damage to " + collision.gameObject.name);
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
