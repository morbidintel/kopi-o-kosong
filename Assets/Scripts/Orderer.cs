using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;
using System.Linq;

public class Orderer : Singleton<Orderer>
{
	private List<Customer> orders = new List<Customer>();
	private Auntie auntie;

	public GameObject customerPrefab;

	private Difficulty difficulty;

	// Start is called before the first frame update
	void Start()
	{
		difficulty = GameController.Instance.difficulty;
		StartCoroutine(AuntieCoroutine());
		StartCoroutine(OrderCoroutine());
	}

	// Update is called once per frame
	void Update()
	{
		foreach (Customer customer in orders)
		{
			if (customer.timeRemaining < 0.0f)
			{
				orders.Remove(customer);
				//@todo: penalty
			}
		}
	}

	IEnumerator AuntieCoroutine()
	{
		while (true)
		{
			GenerateAuntie(difficulty);
			yield return new WaitForSeconds(5);
		}
	}

	IEnumerator OrderCoroutine()
	{
		while (true)
		{
			GenerateOrder(difficulty);
			yield return new WaitForSeconds(10);
		}
	}

	public void checkAndScoreDrink(Drink drink)
	{
		// Fill aunty's orders first!!!!
		if (auntie != null)
		{
			if (auntie.SubmitDrink(drink))
			{
				// SCORE!
				auntie = null;
			}
			return;
		}

		if (orders[0].SubmitDrink(drink)) 
		{
			if(orders[0].IsCompleted()) 
			{
				// SCORE!
				orders[0].OnComplete();
				if (0 + 1 < orders.Count) orders[0 + 1].GetComponent<Customer>().ForceRenderText();

				orders.Remove(orders[0]);
			}

			return;
		}

		// If not fulfilled, do something
		//todo: penalty
	}

	void GenerateOrder(Difficulty stageDifficulty)
	{
		Customer cust = Instantiate(customerPrefab, new Vector3(20f, 0f, 0f), Quaternion.identity, transform).GetComponent<Customer>();
		cust.Init(difficulty, 60.0f);
		orders.Add(cust);
		//orders.Add(new Customer(stageDifficulty, 60.0f));
	}

	void GenerateAuntie(Difficulty stageDifficulty)
	{
		var threshold = 0.15f * stageDifficulty.stageDifficulty - 0.15f;
		if (Random.Range(0f, 1f) < threshold) auntie = new Auntie(stageDifficulty, 10.0f);
	}
}
