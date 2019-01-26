using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timeRemaining;
    public Text scoreText;
    public int score;

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
        Debug.Log("Game Over");
        timeRemaining = 0;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score.ToString();
    }
}
