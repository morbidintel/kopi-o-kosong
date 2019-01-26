using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public Drink drink;
    public float timeRemaining;
    public bool success;

    public Customer(Drink desiredDrink, float timeLimit)
    {
        this.drink = desiredDrink;
        this.timeRemaining = timeLimit;
    }

    public bool SubmitDrink(Drink completedDrink) 
    {
        return this.drink.Equals(completedDrink);
    }

    void Update() {
        this.timeRemaining -= Time.deltaTime;
    }
}