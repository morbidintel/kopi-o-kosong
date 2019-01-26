using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public Drink[] availableDrinks;
    public int maxOrderSize;
    public int minOrderSize =1;

    public List<Drink> GenerateDrinkList()
    {
        maxOrderSize = Random.Range(minOrderSize, maxOrderSize);
        List<Drink> orders = new List<Drink>();
        for (int i=0; i<maxOrderSize; i++)
        {
            orders.Add(availableDrinks[Random.Range(0, availableDrinks.Length - 1)]);
        }
        return orders;
    }
}
