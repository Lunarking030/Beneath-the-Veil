using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float regenRate = 1.0f; // Health regenerated per second
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(regenRate * Time.deltaTime);
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add code here for what happens when the enemy dies
        Destroy(gameObject);
    }
}