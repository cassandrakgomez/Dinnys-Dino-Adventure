using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuManager : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame(){
        Debug.Log("Quit Button Working!");
        Application.Quit();
    }
    public void SettingsMenu(){
        SceneManager.LoadScene("Settings");
    }
}
