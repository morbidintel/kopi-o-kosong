using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{

    private float t;
    private List<Drink> orders;
    private DrinkTypes drinkTypes;
    public GameObject cup;
    // Start is called before the first frame update
    void Start()
    {
        drinkTypes = new DrinkTypes();
        t = Time.time + 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < t)
        {
            GenerateOrder(1);
            UpdateTimeForNextOrder();
        }
    }

    public bool checkAndScoreDrink(Drink drink)
    {
        foreach(Drink order in orders)
        {
            if (order.Equals(drink))
            {
                return true;
            }
        }
        return false;
    }

    void GenerateOrder(int stage)
    {
        var drinkList = drinkTypes.getDrinkList(stage);
        var drinkFormula = drinkList[Random.Range(0, drinkList.Count)];
        orders.Add(new Drink(
                drinkFormula[0],
                drinkFormula[1],
                drinkFormula[2],
                drinkFormula[3],
                drinkFormula[4],
                drinkFormula[5]
            ));
    }

    void UpdateTimeForNextOrder()
    {
        t = Time.time + 30 + Random.value * 30; //30 to 60 seconds.
    }
}
