using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool paused;

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

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if(paused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
        
        GameUI.instance.TogglePauseScreen(paused);
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
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        GameUI.instance.SetEndScreen(false);
        Time.timeScale = 0.0f;
    }
}

