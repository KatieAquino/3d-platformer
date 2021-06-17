using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    // Instance for easier access.
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
    }

    public void LevelEnd()
    {
        // Checks to see if last level.
        if(SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1);
        {
            // Display win screen.
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void WinGame()
    {
        // TODO
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

