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
        // Ensure that game object is not destroyed if it is a new level.
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
        GameUI.instance.UpdateScoreText();
    }
    public void ResetScore()
    {
        score = 0;
        GameUI.instance.UpdateScoreText();
    
    }
    public void LevelEnd()
    {
        // Checks to see if last level.
        if(SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
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
        GameUI.instance.SetEndScreen(true);
    }

    public void GameOver()
    {
        GameUI.instance.SetEndScreen(false);
    }
}

