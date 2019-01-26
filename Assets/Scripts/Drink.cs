using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public int sugarLevel;
    public int drinkKopi;
    public int drinkTeh;
    public int milkCondensed;
    public int milkEvaporated;
    public int iceLevel;

    // Initialise an empty drink, for starting a new order fulfilment.
    public Drink() { }

    // Initialise with specific types. For orders.
    public Drink(int sugarLevel, int drinkKopi, int drinkTeh, int milkCondensed, int milkEvaporated, int iceLevel)
    {
        this.sugarLevel = sugarLevel;
        this.drinkKopi = drinkKopi;
        this.drinkTeh = drinkTeh;
        this.milkCondensed = milkCondensed;
        this.milkEvaporated = milkEvaporated;
        this.iceLevel = iceLevel;
    }

    public void AddDrinkKopi()
    {
        drinkKopi++;
    }

    public void AddDrinkTeh()
    {
        drinkTeh++;
    }

    public void AddMilkEvaporated()
    {
        milkEvaporated++;
    }

    public void AddMilkCondensed()
    {
        milkCondensed++;
    }

    public void AddIce()
    {
        iceLevel++;
    }

    public void AddSugar()
    {
        sugarLevel++;
    }

    // Print name of the drink.
    public string ToString()
    {
        return "";
    }

    // Check equivalency of 2 drinks.
    public bool Equals(Drink other)
    {
        return other.sugarLevel == sugarLevel &&
            other.drinkTeh == drinkTeh &&
            other.drinkKopi == drinkKopi &&
            other.milkEvaporated == milkEvaporated &&
            other.milkCondensed == milkCondensed &&
            other.iceLevel == iceLevel;
    }
}
