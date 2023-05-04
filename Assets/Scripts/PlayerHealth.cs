using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject gameOverScreen;
    public GameObject damageText;
    public float acidballDamageOverTime = 5f;
    public float acidballDamageDuration = 2f;

    public bool isTakingAcidDamage = false;
    private float acidballDamageEndTime;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (isTakingAcidDamage && Time.time < acidballDamageEndTime)
        {
            TakeDamage(Mathf.RoundToInt(acidballDamageOverTime * Time.deltaTime));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);

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

    public void TakeAcidDamage()
    {
        if (!isTakingAcidDamage)
        {
            isTakingAcidDamage = true;
            acidballDamageEndTime = Time.time + acidballDamageDuration;
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
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        // Unfreeze the movement of the camera or other relevant objects
    }
}