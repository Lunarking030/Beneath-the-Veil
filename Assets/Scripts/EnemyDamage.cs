using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public int damageIncreasePerSecond = 2;
    private float timeElapsed = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                int currentDamageAmount = damageAmount + (int)(timeElapsed * damageIncreasePerSecond);
                Debug.Log("Dealing " + currentDamageAmount + " damage to " + collision.gameObject.name);
                playerHealth.TakeDamage(currentDamageAmount);
            }
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }
}