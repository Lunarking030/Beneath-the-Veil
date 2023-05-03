using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject gameOverScreen;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
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
            healthSlider.value = 0f; // Set the health bar value to zero
        }
        else
        {
            healthSlider.value = currentHealth;
        }
    }

    private void Die()
    {
    healthSlider.value = 0f; // Set the health bar value to 0
    gameOverScreen.SetActive(true);
    Time.timeScale = 0f; // Pause the game
    gameObject.SetActive(false); // Disable the player GameObject
    Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    Cursor.visible = true; // Make the cursor visible

    // Stop the background music
    GameObject musicObject = GameObject.FindGameObjectWithTag("BackgroundMusic");
    if (musicObject != null)
    {
        AudioSource musicSource = musicObject.GetComponent<AudioSource>();
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        // Unfreeze the movement of the camera or other relevant objects
    }
}