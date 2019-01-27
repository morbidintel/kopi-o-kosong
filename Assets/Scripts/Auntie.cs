using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class Auntie : Customer
{
    // Start is called before the first frame update
    public Drink requestedDrink;

	private int numOfDrinkCompleted = 0;
	private int numOfDrinkToDo;
	private Difficulty difficulty;
	public int randomNumOfDrink = 2;

	public GameObject[] AuntieShout = new GameObject[2];

	public void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		int index = Random.Range(0, 1);
		spriteRenderer.sprite = characters[index];

		progressBar = GetComponentInChildren<ProgressBar>();
	}

    public Auntie(Difficulty difficulty, float timeLimit)
    {
        this.requestedDrink = difficulty.GenerateDrinkList()[0];
        this.timeRemaining = timeLimit;
		numOfDrinkToDo = Random.Range(0, randomNumOfDrink);

		this.difficulty = difficulty;

		// Summon Scream
		Instantiate(AuntieShout[Random.Range(0, 2)], transform).GetComponent<TextMeshPro>().text = "Hello";
    }

	// Override
    public bool SubmitDrink(Drink completedDrink)
    {
        if (requestedDrink.Equals(completedDrink))
        {
            return true;
        }
        return false;
    }

	public bool IsAuntieFinished() 
	{
		if (numOfDrinkCompleted < numOfDrinkToDo) 
		{
			// Reset drink here
			this.requestedDrink = difficulty.GenerateDrinkList()[0];
			ClearText();
			ForceRenderText();
			return false;
		}

		return true;
	}

    void Update()
    {
		timeRemaining -= Time.deltaTime;
		progressBar.setProgress(timeRemaining / totalTime);
    }

	public void RenderText()
	{
		// Do not render text when it is not the object in front
		if (transform.GetSiblingIndex() != 0)
			return;
		SetSpeech(true);
		ForceRenderText();
	}

	public void ForceRenderText()
	{
		List<string> incompleteDrinks = new List<string>();
		List<string> completeDrinks = new List<string>();
		SetSpeech(true);

		tmp.text = "I would like a " + drinkWanted + ".";

		Debug.Log(tmp.text);
		tmp.GetComponentInParent<VertexJitter>().StartAnim();
	}


}