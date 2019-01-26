using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{

    private float t;
    private List<Customer> orders;
    private DrinkTypes drinkTypes;
    private Difficulty difficulty;
    // Start is called before the first frame update
    void Start()
    {
        drinkTypes = new DrinkTypes();
        t = Time.time + 60;
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
    }

    public void checkAndScoreDrink(Drink drink)
    {
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
    }

    void GenerateOrder(Difficulty stageDifficulty)
    {
        //todo: fix this
        orders.Add(new Customer(stageDifficulty, 60.0f));
    }

    void UpdateTimeForNextOrder()
    {
        t = Time.time + 30 + Random.value * 30; //30 to 60 seconds.
    }
}
