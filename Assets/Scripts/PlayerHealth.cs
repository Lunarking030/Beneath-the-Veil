using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject gameOverScreen;
    public GameObject damageText;

    public GameObject statKeep;

    private void Start()
    {
        maxHealth = Convert.ToInt32(statKeep.gameObject.GetComponent<Stats>().maxHealth);
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        healthSlider.value = statKeep.GetComponent<Stats>().health;
        healthSlider.maxValue = statKeep.GetComponent<Stats>().maxHealth;
    }

    public void TakeDamage(int damage)
    {
        statKeep.gameObject.GetComponent<Stats>().health -= damage;
        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);

        if (statKeep.gameObject.GetComponent<Stats>().health <= 0)
        {
            Die();
            Time.timeScale = 0f;
            // Freeze the movement of the camera or other relevant objects
            healthSlider.value = 0f; // Set the health bar value to zero
        }
        else
        {
            healthSlider.value = statKeep.gameObject.GetComponent<Stats>().health;
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
        statKeep.gameObject.GetComponent<Stats>().maxHealth = 100f;
        statKeep.gameObject.GetComponent<Stats>().health = 100f;
        healthSlider.value = Convert.ToInt32(statKeep.gameObject.GetComponent<Stats>().maxHealth);
        // Unfreeze the movement of the camera or other relevant objects
    }
}
