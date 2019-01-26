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
    }

    public List<Drink> GenerateDrinkList()
    {
        maxOrderSize = Random.Range(minOrderSize, maxOrderSize);
        List<Drink> orders = new List<Drink>();
        for (int i=0; i<maxOrderSize; i++)
        {
            int[] drinkFormula = DrinkTypes.Types[availableDrinks[Random.Range(0, availableDrinks.Count - 1)]];
            orders.Add(new Drink(
                drinkFormula[0],
                drinkFormula[1],
                drinkFormula[2],
                drinkFormula[3],
                drinkFormula[4],
                drinkFormula[5]
            ));
        }
        return orders;
    }
}
