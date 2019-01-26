using UnityEngine;
using System.Collections;
using Gamelogic.Extensions;

public class PlayerDrink : Singleton<PlayerDrink>
{
    public Drink drink;

    [SerializeField]
    SpriteRenderer sprite;

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
        Orderer.Instance.checkAndScoreDrink(drink);
        drink = new Drink();
    }

    void renderDrink()
    {
        bool isKopi = drink.drinkKopi > 0;
        bool isTeh = drink.drinkTeh > 0;
        bool hasMilk = drink.milkCondensed == 1 || drink.milkEvaporated == 1;
        bool hasIce = drink.iceLevel > 0;

        if (isKopi)
        {
            sprite.color = new Color(78f, 50f, 41f); 
        }
        else if (isTeh)
        {
            sprite.color = new Color(122f, 47f, 24f); 
        }
        if (hasMilk)
        {
            if (isKopi) {
                sprite.color = new Color(132f, 87f, 48f);
            } else if (isTeh) {
                sprite.color = new Color(202f, 148f, 78f);
            }
        }
        if (hasIce)
        {
            // Add ice
        }
    }
}
