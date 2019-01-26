using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auntie : MonoBehaviour
{
    // Start is called before the first frame update
    public Drink requestedDrink;
    public float timeRemaining;
    public bool success;

    public Auntie(Difficulty difficulty, float timeLimit)
    {
        this.requestedDrink = difficulty.GenerateDrinkList()[0];
        this.timeRemaining = timeLimit;
    }

    public bool SubmitDrink(Drink completedDrink)
    {
        if (requestedDrink.Equals(completedDrink))
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        this.timeRemaining -= Time.deltaTime;
    }
}