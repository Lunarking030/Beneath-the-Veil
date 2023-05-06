using System.Diagnostics;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public int damageIncreasePerSecond = 2;
    private float timeElapsed = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Object collided with " + collision.gameObject.name);

        // Check if collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                int currentDamageAmount = damageAmount + (int)(timeElapsed * damageIncreasePerSecond);
                UnityEngine.Debug.Log("Dealing " + currentDamageAmount + " damage to " + collision.gameObject.name);
                playerHealth.TakeDamage(currentDamageAmount);
            }
        }

        // Check if collided object is a projectile and was fired by the player
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Shooter shooter = collision.gameObject.GetComponent<Shooter>();
            if (shooter != null && shooter.CompareTag("Player"))
            {
                EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    int currentDamageAmount = damageAmount + (int)(timeElapsed * damageIncreasePerSecond);
                    UnityEngine.Debug.Log("Dealing " + currentDamageAmount + " damage to " + gameObject.name);
                    enemyHealth.TakeDamage(currentDamageAmount);
                }
            }
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }
}
