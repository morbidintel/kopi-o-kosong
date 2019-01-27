using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty
{
    public List<string> availableDrinks;
    public int maxOrderSize;
    public int minOrderSize = 1;
    public int stageDifficulty;

    public Difficulty(int difficulty)
    {
        maxOrderSize = 1 + Mathf.RoundToInt((difficulty - 1) / 2);

        stageDifficulty = difficulty;
        availableDrinks = new List<string>();
        availableDrinks.Add("kopi o");
        availableDrinks.Add("kopi");
        availableDrinks.Add("teh o");
        availableDrinks.Add("teh");

        if (difficulty >= 2)
        {
            availableDrinks.Add("kopi o peng");
            availableDrinks.Add("kopi peng");
            availableDrinks.Add("teh o peng");
            availableDrinks.Add("teh peng");
            availableDrinks.Add("teh siew dai");
            availableDrinks.Add("kopi siew dai");
        }
  
        if (difficulty >= 3)
        {
            availableDrinks.Add("teh siew dai peng");
            availableDrinks.Add("kopi siew dai peng");
            availableDrinks.Add("teh gau");
            availableDrinks.Add("teh o gau");
            availableDrinks.Add("kopi gau");
            availableDrinks.Add("kopi o gau");
            availableDrinks.Add("kopi kosong");
            availableDrinks.Add("teh kosong");
            availableDrinks.Add("kopi o kosong");
            availableDrinks.Add("teh o kosong");
        }
        //todo: stage 4 and 5
        if (difficulty >= 4) {
            availableDrinks.Add("teh gau peng");
            availableDrinks.Add("teh o gau peng");
            availableDrinks.Add("kopi gau peng");
            availableDrinks.Add("kopi o gau peng");
            availableDrinks.Add("kopi kosong peng");
            availableDrinks.Add("teh kosong peng");
            availableDrinks.Add("kopi o kosong peng");
            availableDrinks.Add("teh o kosong peng");
            availableDrinks.Add("teh c");
            availableDrinks.Add("teh c kosong");
            availableDrinks.Add("teh c siew dai");
            availableDrinks.Add("kopi c");
            availableDrinks.Add("kopi c kosong");
            availableDrinks.Add("kopi c siew dai");   
        }

        if (difficulty >= 5) {
            availableDrinks.Add("teh c peng");
            availableDrinks.Add("teh c kosong peng");
            availableDrinks.Add("teh c peng siew dai");
            availableDrinks.Add("kopi c peng");
            availableDrinks.Add("kopi c kosong peng");
            availableDrinks.Add("kopi c peng siew dai"); 
            availableDrinks.Add("teh o siew dai");
            availableDrinks.Add("teh o peng siew dai");
            availableDrinks.Add("kopi o siew dai");
            availableDrinks.Add("kopi o peng siew dai");
        }
    }

    public Drink GetDrink()
    {
        int[] drinkFormula = DrinkTypes.Types[availableDrinks[Random.RandomRange(0, availableDrinks.Count)]];
        return new Drink(drinkFormula[0],
                drinkFormula[1],
                drinkFormula[2],
                drinkFormula[3],
                drinkFormula[4],
                drinkFormula[5]);
    }

    public static Difficulty GetDifficulty(int score)
    {
        if (score < 3 * 60) 
        {
            return new Difficulty(1);
        }
        else if (score < 6 * 60)
        {
            return new Difficulty(2);
        }
        else if (score < 12 * 60)
        {
            return new Difficulty(3);
        }
        else if (score < 18 * 60)
        {
            return new Difficulty(4);
        }
        return new Difficulty(5);
        
    }
}
