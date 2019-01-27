using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public const float maxTimeRemaining = 60f;
    public float timeRemaining;
    public float restartDelay = 4f;
    public GameObject gameOverPanel;
    public Text scoreText;
    public int score;
    private int oldScore;
    bool gameHasEnded;
    public Difficulty difficulty = new Difficulty(1);

    void Start()
    {
        timeRemaining = 60;
        StartCoroutine(InitiateUIButtons());
    }

    IEnumerator InitiateUIButtons()
    {
        GameObject qButton = GameObject.Find("Q");
        GameObject wButton = GameObject.Find("W");
        GameObject eButton = GameObject.Find("E");
        GameObject rButton = GameObject.Find("R");
        GameObject tButton = GameObject.Find("T");
        GameObject yButton = GameObject.Find("Y");

        ConfigureText(qButton, "Q");
        ConfigureText(wButton, "W");
        ConfigureText(eButton, "E");
        ConfigureText(rButton, "R");
        ConfigureText(tButton, "T");
        ConfigureText(yButton, "Y");
        yield return new WaitForSeconds(10);

        HideButton(qButton);
        HideButton(wButton);
        HideButton(eButton);
        HideButton(rButton);
        HideButton(tButton);
        HideButton(yButton);
    }

    void HideButton(GameObject button)
    {
        button.SetActive(false);
    }
    void ConfigureText(GameObject buttonText, string newText)
    {
        buttonText.GetComponentInChildren<Text>().fontSize = 40;
        buttonText.GetComponentInChildren<Text>().text = newText;
        buttonText.GetComponentInChildren<Text>().color = Color.white;
    }

    void Update()
    {
        UpdateScore();
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            GameOver();
        }
        difficulty = Difficulty.GetDifficulty(score);
    }

    void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
            UpdateScore();
            gameOverPanel.SetActive(true);
		}
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int value)
    {
        score += value;
    }

    void UpdateScore()
    {
        if (score != oldScore)
        {
            oldScore++;
            scoreText.GetComponent<Text>().text = oldScore.ToString();
        }
    }

	public void AddTime(int difficulty)
	{
        int timeIncrement = 10 - difficulty;
		timeRemaining = Mathf.Min(timeRemaining += timeIncrement, maxTimeRemaining);
        Debug.Log(timeRemaining);
    }
}
