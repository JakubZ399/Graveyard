using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    private GameObject pauseMenu;

    public void Start()
    {
        pauseMenu = GameObject.Find("Pause_Menu"); // Find the Pause_Menu GameObject in the scene
        pauseMenu.SetActive(false); // Hide the pause menu initially
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; 
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}