using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    enum SugarLevel {KOSONG, SIEW_DAI, NORMAL, SWEET_AF};
    enum DrinkType {TEH, KOPI};
    enum MilkType {O, C, NORMAL}
    enum IceLevel {NONE, PENG}

    public int sugarLevel;
    public DrinkType drinkType;
    public MilkType milkType;
    public IceLevel iceLevel;

    // Initialise an empty drink, for starting a new order fulfilment.
    public Drink() {}

    // Initialise with specific types. For orders.
    public Drink(DrinkType drinkType, MilkType milkType, int sugarLevel, IceLevel iceLevel) 
    {
        this.drinkType = drinkType;
        this.milkType = milkType;
        this.sugarLevel = sugarLevel;
        this.iceLevel = iceLevel;
    }

    public void AddDrink() 
    {

    }

    public void AddMilk() 
    {

    }

    public void AddSugar() 
    {

    }

    public void AddIce() 
    {

    }

    // Print name of the drink.
    public void ToString() 
    {
        return this.PrintEnum(this.drinkType.ToString()) + 
            this.PrintEnum(this.milkType.ToString()) +
            this.PrintEnum(this.GetSugarLevel(this.SugarLevel.ToString())) +
            this.PrintEnum(this.iceLevel.ToString());
    }

    // Check equivalency of 2 drinks.
    public void Equals(Drink other) 
    {
        return other.drinkType == this.drinkType &&
            other.milkType == this.milkType &&
            other.sugarLevel == this.sugarLevel &&
            other.iceLevel == this.iceLevel;
    }

    private string PrintEnum(string value) 
    {
        if (value.Equals("NORMAL") || value.Equals("NONE"))
        {
            return "";
        } 
        else 
        {
            return value.Replace("_", " ");
        }
    }

    private SugarLevel GetSugarLevel(int sugarLevel)
    {
        if (Enum.IsDefined(typeof(SugarLevel), sugarLevel)) 
        {  
            return (SugarLevel) sugarLevel;
        }
        else 
        {
            return SugarLevel.SWEET_AF;
        }
    }
}
