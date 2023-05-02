using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Scrollbar healthBar;
    public GameObject gameOverScreen;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.size = 1f;
        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            healthBar.size = (float)currentHealth / (float)maxHealth;
        }
    }

    private void Die()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
