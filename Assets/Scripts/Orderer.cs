using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{
    private float t;
    private float t_auntie;
    private List<Customer> orders;
    private Auntie auntie;

    private Difficulty difficulty;

    // Start is called before the first frame update
    void Start()
    {
        t = Time.time + 60;
        t_auntie = Time.time + 15;
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

        if (Time.time < t)
        {
            GenerateOrder(difficulty);
            UpdateTimeForNextOrder();
        }

        if (Time.time < t_auntie)
        {
            GenerateAuntie(difficulty);
            UpdateTimeForNextAuntie();
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
        orders.Add(new Customer(stageDifficulty, 60.0f));
    }

    void GenerateAuntie(Difficulty stageDifficulty)
    {
        var threshold = 0.15f * stageDifficulty.stageDifficulty - 0.15f;
        if (Random.Range(0f, 1f) < threshold) auntie = new Auntie(stageDifficulty, 10.0f);
    }

    void UpdateTimeForNextOrder()
    {
        t = Time.time + 30 + Random.value * 30; //30 to 60 seconds.
    }

    void UpdateTimeForNextAuntie()
    {
        t_auntie = Time.time + 15;
    }
}
