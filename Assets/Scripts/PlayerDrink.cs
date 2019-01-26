using UnityEngine;
using System.Collections;

public class PlayerDrink : MonoBehaviour
{
    public Orderer orderer;
    public Drink drink;
    // Use this for initialization
    void Start()
    {
        drink = new Drink();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void empty()
    {
        drink = new Drink();
    }

    public void serve()
    {
        //scoring logic;
        orderer.checkAndScoreDrink(drink);
        drink = new Drink();
    }
}
