using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{

    private bool isNearby = false;

    void Update(){
        if (isNearby && Input.GetKeyDown(KeyCode.W)){
            MoveOn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearby = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearby = false;
        }
    }

    public void MoveOn(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if(nextScene < SceneManager.sceneCountInBuildSettings){

            SceneManager.LoadScene(nextScene);
        }
        else{
            SceneManager.LoadScene("MainMenu");
        }

    }

}