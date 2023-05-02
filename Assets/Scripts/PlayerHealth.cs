using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
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
            Time.timeScale = 0f;
            // Freeze the movement of the camera or other relevant objects
        }
        else
        {
            healthBar.size = (float)currentHealth / (float)maxHealth;
        }
    }

    private void Die()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        // Unfreeze the movement of the camera or other relevant objects
    }
}
