using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float levelTime = 5f; // Total time for the level
    public TextMeshProUGUI TimerText; // TextMesh Pro UI element for displaying the timer
    public GameEnding gameEnding; // Reference to the GameEnding script

    private float timeRemaining;
    private bool isGameActive = true;

    void Start()
    {
        timeRemaining = levelTime; // Initialize the timer
    }

    void Update()
    {
        if (isGameActive)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            isGameActive = false;
            TimerText.text = "Time's Up!";
            //Destroy(TimerText);

            // Trigger game end through the GameEnding script
            gameEnding.CaughtPlayer();
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Format the time as MM:SS
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimerText.text = $"{minutes:00}:{seconds:00}";
    }
}