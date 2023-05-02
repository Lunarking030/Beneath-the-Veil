using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime;
    private float timeElapsed;
    public Text timerText;
    private bool gameStarted = true;

    void Start()
    {
        timeElapsed = 0f;
    }

    void Update()
    {
        // Only count up the timer if the game has started and the player is alive
        if (gameStarted)
        {
            timeElapsed += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }

}
