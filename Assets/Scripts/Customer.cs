using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
	// Start is called before the first frame update
	public List<Drink> incomplete = new List<Drink>();
	public List<Drink> fulfilled = new List<Drink>();
	public float timeRemaining;
	public bool success;

	[SerializeField]
	UnityEvent onComplete;

	public void Init(Difficulty difficulty, float timeLimit)
	{
		incomplete = difficulty.GenerateDrinkList();
		timeRemaining = timeLimit;
	}

	public bool SubmitDrink(Drink completedDrink)
	{
		foreach (Drink drink in incomplete)
		{
			if (drink.Equals(completedDrink))
			{
				incomplete.Remove(drink);
				fulfilled.Add(drink);
				return true;
			}
		}
		return false;
	}

	public bool IsCompleted()
	{
		return (incomplete.Count == 0);
	}

	public void OnComplete()
	{
		onComplete.Invoke();
	}

	void Update()
	{
		timeRemaining -= Time.deltaTime;
	}

	public void OnFinishTween()
	{
		Destroy(gameObject);
	}
}