using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int noOfScenes = 4;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if ((currentSceneIndex + 1) % noOfScenes == 0)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
            SceneManager.LoadScene((currentSceneIndex + 1) % noOfScenes);
        
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
}