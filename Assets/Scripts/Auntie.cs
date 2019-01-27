using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class Auntie : Customer
{
    // Start is called before the first frame update

	private Difficulty difficulty;

	public GameObject[] AuntieShout = new GameObject[2];

	public void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		int index = Random.Range(0, 1);
		spriteRenderer.sprite = characters[index];

		progressBar = GetComponentInChildren<ProgressBar>();
	}

    public Auntie(Difficulty difficulty, float timeLimit, Drink drinkWanted)
    {
		// Summon Scream
		// Instantiate(AuntieShout[Random.Range(0, 2)], transform).GetComponent<TextMeshPro>().text = "Hello";
    }

	public void Init(Difficulty difficulty, float timeLimit, Drink drinkWanted)
	{
		timeRemaining = timeLimit;
		totalTime = timeLimit;
		this.drinkWanted = drinkWanted;
	}

	// Override
    public bool SubmitDrink(Drink completedDrink)
    {
		return completedDrink.Equals(drinkWanted);
    }

    void Update()
    {
		timeRemaining -= Time.deltaTime;
		progressBar.setProgress(timeRemaining / totalTime);
    }

	public void MoveTo(Vector3 location)
	{
		transform.DOMove(location, 1).OnComplete(RenderText);
		int loops = Mathf.Abs(Mathf.FloorToInt(location.x - transform.position.x)) / 2;
		if (loops > 2)
		{
			transform.DOMoveY(.5f, 1f / loops)
				.SetLoops(loops - 2, LoopType.Yoyo)
				.SetDelay(loops % 2 == 1 ? 1f / loops / 2f : 0);
		}
	}

	public void RenderText()
	{
		// RENDER CAUSE ITS AUNTIE
		SetSpeech(true);
		ForceRenderText();
	}

	public void ForceRenderText()
	{
		List<string> incompleteDrinks = new List<string>();
		List<string> completeDrinks = new List<string>();
		SetSpeech(true);

		tmp.text = drinkWanted + " PLS";

		Debug.Log(tmp.text);
		tmp.GetComponentInParent<VertexJitter>().StartAnim();
	}


}