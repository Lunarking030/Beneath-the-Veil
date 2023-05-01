using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject GmCanvas;

    public int health = 100; // the player's starting health

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // subtract the damage amount from the player's health

        if (health <= 0)
        {
            Die(); // if the player's health is zero or less, call the Die function
        }
    }

    void Die()
    {
        // add any necessary code here for when the player dies
        
        
        Destroy(gameObject); // destroy the player object
        GmCanvas.SetActive(true);

    }



    void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}