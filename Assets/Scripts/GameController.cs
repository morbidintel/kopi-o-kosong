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
