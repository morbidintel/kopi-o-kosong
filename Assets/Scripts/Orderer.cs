using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{

    private float t;
    private List<Customer> orders;
    private DrinkTypes drinkTypes;
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
            GenerateOrder(1);
            UpdateTimeForNextOrder();
        }
    }

    public bool checkAndScoreDrink(Drink drink)
    {
        foreach(Customer customer in orders)
        {
            if (customer.SubmitDrink(drink))
            {
                
                return true;
            }
        }
        return false;
    }

    void GenerateOrder(int stage)
    {
        var drinkList = drinkTypes.getDrinkList(stage);
        var drinkFormula = drinkList[Random.Range(0, drinkList.Count)];
        orders.Add(new Customer(
            new Drink(
                drinkFormula[0],
                drinkFormula[1],
                drinkFormula[2],
                drinkFormula[3],
                drinkFormula[4],
                drinkFormula[5]
            ), 60.0f));
    }

    void UpdateTimeForNextOrder()
    {
        t = Time.time + 30 + Random.value * 30; //30 to 60 seconds.
    }
}
