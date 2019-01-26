using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gamelogic.Extensions;

public class GameController : Singleton<GameController>
{
    public const float maxTimeRemaining = 60f;
    public float timeRemaining;
    public float timeIncrement;
    public float restartDelay = 4f;
    public Text scoreText;
    public int score;
    private int oldScore;
    bool gameHasEnded;
    public Difficulty difficulty = new Difficulty(1);

    void Start()
    {
        timeRemaining = 60;
    }

    void Update()
    {
        UpdateScore();
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
            UpdateScore();
            Restart();
        }
        
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int value)
    {
        score += value;
    }

    void UpdateScore() {
        if (score != oldScore)
        {
            oldScore++;
            scoreText.GetComponent<Text>().text = oldScore.ToString();
        }
    }

    public void AddTime() {
        timeRemaining = Mathf.Min(timeRemaining += timeIncrement, maxTimeRemaining);
    }
}
