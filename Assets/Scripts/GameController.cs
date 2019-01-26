using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const float maxTimeRemaining = 60f;
    public float timeRemaining;
    public float timeIncrement;
    public float restartDelay = 4f;
    public Text scoreText;
    public int score;
    bool gameHasEnded;

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

    public void AddScore(){
        
    }

    void UpdateScore() {
        //scoreText.text = "Score: " + score.ToString();
    }

    public void AddTime() {
        timeRemaining = Mathf.Min(timeRemaining += timeIncrement, maxTimeRemaining);
    }
}
