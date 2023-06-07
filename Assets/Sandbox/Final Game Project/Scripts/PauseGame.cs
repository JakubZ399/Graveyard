using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject gameUI;
    public GameObject playerObj;

    public void Start()
    {
        pauseMenu.SetActive(false); // Hide the pause menu initially
        playerObj.GetComponent<Movement>().enabled = true;
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
        playerObj.GetComponent<Movement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameUI.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        pauseMenu.SetActive(false);
        playerObj.GetComponent<Movement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        gameUI.SetActive(true);
    }
}