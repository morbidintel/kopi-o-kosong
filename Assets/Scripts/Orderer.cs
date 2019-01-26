using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{
    private List<Customer> orders = new List<Customer>();
    private Auntie auntie;

    public GameObject customerPrefab;

    private Difficulty difficulty = new Difficulty(1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AuntieCoroutine());
        StartCoroutine(OrderCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Customer customer in orders)
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
        while(true)
        {
            yield return new WaitForSeconds(5);
            GenerateAuntie(difficulty);
        }
    }

    IEnumerator OrderCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            GenerateOrder(difficulty);
        }
    }

    public void checkAndScoreDrink(Drink drink)
    {
        if (auntie != null)
        {
            if (auntie.SubmitDrink(drink))
            {
                // SCORE!
                auntie = null;
            }
            return;
        }

        foreach (Customer customer in orders)
        {
            if (customer.SubmitDrink(drink))
            {
                //check if completed and score
                if (customer.completed())
                {
                    //SCORE!
                }

                return;
            }
        }
        //todo: penalty
    }

    void GenerateOrder(Difficulty stageDifficulty)
    {
        Customer cust = Instantiate(customerPrefab).GetComponent<Customer>();
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
