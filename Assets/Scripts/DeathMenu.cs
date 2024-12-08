using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject GameOverUI; // UI panel to display when the game is over
    public AudioSource backgroundMusic; // Reference to the background music AudioSource


    public void TriggerGameOver()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); 
        }

        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void TryAgain()
    {
        Time.timeScale = 1f; 
        
        SceneManager.LoadScene(flag.LastScene); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}

