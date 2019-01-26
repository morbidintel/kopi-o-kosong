using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    enum SugarLevel {KOSONG, SIEW_DAI, NORMAL};
    enum DrinkType {TEH, KOPI};
    enum MilkType {O, C, NORMAL}
    enum IceLevel {NONE, PENG}

    public SugarLevel sugarLevel;
    public DrinkType drinkType;
    public MilkType milkType;
    public IceLevel iceLevel;

    // Initialise an empty drink, for starting a new order fulfilment.
    public Drink() {}

    // Initialise with specific types. For orders.
    public Drink(DrinkType drinkType, MilkType milkType, SugarLevel sugarLevel, IceLevel iceLevel) {
        this.drinkType = drinkType;
        this.milkType = milkType;
        this.sugarLevel = sugarLevel;
        this.iceLevel = iceLevel;
    }

    // Print name of the drink.
    public ToString() 
    {
        return printEnum(drinkType.ToString()) + 
            printEnum(milkType.ToString()) +
            printEnum(sugarLevel.ToString()) +
            printEnum(iceLevel.ToString());
    }

    // Check equivalency of 2 drinks.
    public Equals(Drink other) 
    {
        return other.drinkType == this.drinkType &&
            other.milkType == this.milkType &&
            other.sugarLevel == this.sugarLevel &&
            other.iceLevel == this.iceLevel;
    }

    private string printEnum(string value) 
    {
        if (value.Equals("NORMAL") || value.Equals("NONE")) {
            return "";
        } else {
            return value.Replace("_", " ");
        }
    }
}
