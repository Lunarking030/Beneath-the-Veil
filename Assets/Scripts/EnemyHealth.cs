using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyHealth : MonoBehaviour
{
    public string enemyName;
    public int maxHealth = 100;
    public float regenRate = 1.0f; // Health regenerated per second
    private int currentHealth;
    public Slider healthSlider;
    public UnityEngine.UI.Text nameText;
    public GameObject damageText;
    public Shooter shooter;
    public float damageMultiplier = 1.0f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        nameText.text = enemyName;
        shooter = GameObject.FindWithTag("Player").GetComponent<Shooter>();
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(regenRate * Time.deltaTime);
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthSlider.value = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(shooter.damageAmount);
            Destroy(other.gameObject);
        }
       else if (other.CompareTag("Enemy"))
       {
            TakeDamage(40); // Assuming a fixed damage value of 10 when hit by another enemy
      }
    }

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }



}
