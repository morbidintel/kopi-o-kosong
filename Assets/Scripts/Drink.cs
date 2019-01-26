using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drink
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
    public override string ToString()
    {
        if (drinkKopi + drinkTeh > 1 ||
            milkCondensed + milkEvaporated > 1 ||
            sugarLevel > 2 ||
            iceLevel > 1)
        {
            return "???";
        }

        return string.Join(" ", new string[]{ 
            PrintDrinkStr(drinkKopi, drinkTeh),
            PrintMilkStr(milkEvaporated, milkCondensed),
            PrintSugarStr(sugarLevel),
            PrintIceStr(iceLevel)}).Trim();
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

    private string PrintDrinkStr(int kopi, int teh)
    {
        if (kopi == 1)
        {
            return "KOPI";
        }
        if (teh == 1)
        {
            return "TEH";
        }
        return "";
    }

    private string PrintMilkStr(int evap, int cond)
    {
        if (evap == 1)
        {
            return "C";
        }
        if (cond == 1)
        {
            return "";
        }
        return "O";

    }

    private string PrintSugarStr(int sugar)
    {
        switch (sugar)
        {
            case 0: return "KOSONG";
            case 1: return "SIEW DAI";
            default: return "";
        }
    }

    private string PrintIceStr(int ice)
    {
        if (ice == 1)
        {
            return "PENG";
        }
        return "";
    }
}
