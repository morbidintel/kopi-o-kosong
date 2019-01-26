using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Drink> incomplete;
    public List<Drink> fulfilled;
    public float timeRemaining;
    public bool success;

    public Customer(Difficulty difficulty, float timeLimit)
    {
        this.incomplete = difficulty.GenerateDrinkList();
        this.timeRemaining = timeLimit;
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

    public bool completed()
    {
        return (incomplete.Count == 0);
    }

    void Update()
    {
        this.timeRemaining -= Time.deltaTime;
    }
}