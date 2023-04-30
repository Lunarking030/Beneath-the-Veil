using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }


    }


   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    //For PC, remove public so that this function is paused when clicking the Escape Key
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused= true;

    }

       //this is to load the MainMenu from the Pause Menu
   // public void LoadMenu()
    //{
       
      //  SceneManager.LoadScene("MainMenu");

    //}

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }



}
