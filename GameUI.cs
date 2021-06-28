using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;
    public GameObject pauseScreen;

    // Instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        // 
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen(bool hasWon)
    {
        endScreen.SetActive(true);

        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        if(hasWon)
        {
            endScreenHeader.text = "You Win!";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.color = Color.red;
            endScreenHeader.text = "Game Over";
            
        
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void OnRestartButton()
    {
        GameManager.instance.ResetScore();
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(1);
    }

    public void OnMenuButton()
    {
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(0);
    }

    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }
}
