using UnityEngine;
using System.Collections;
using Gamelogic.Extensions;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerDrink : Singleton<PlayerDrink>
{
    public Drink drink;

    public GameObject cMilk;
    public GameObject liquid;
    public GameObject ice;
    public GameObject milk;

    public GameObject fx;

    private Color tehColor = new Color(255, 194, 70);
    private Color kopiColor = new Color(145, 124, 72);
    private Color tehWithMilkColor = new Color(202, 148, 78);
    private Color kopiWithMilkColor = new Color(132, 87, 48);

    // Use this for initialization
    void Start()
    {
        drink = new Drink();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Empty()
    {
		ice.gameObject.SetActive(false);
        drink = new Drink();
    }

    public void Serve()
    {
		//scoring logic;
		ice.gameObject.SetActive(false);
		bool success = Orderer.Instance.checkAndScoreDrink(drink);
        if (success)
        {
            fx.GetComponent<ParticleSystem>().Play();
            DOTween.Restart(gameObject, "shakeCup");
        }
        drink = new Drink();
    }

    public void RenderDrink()
    {
        DrawLiquid(drink);
        DrawCMilk(drink);
    }

    private void DrawLiquid(Drink drink)
    {
        if (drink.drinkKopi + drink.drinkTeh == 0)
        {
            liquid.SetActive(false);
            if (drink.milkEvaporated > 0)
            {
                milk.SetActive(true);
            }
            else
            {
                milk.SetActive(false);
            }
            return;
        }
        milk.SetActive(false);
        liquid.SetActive(true);

        var img = liquid.GetComponent<Image>();
        if (drink.drinkKopi >= 1)
        {

            img.color = kopiColor;
            if (drink.milkEvaporated > 0)
            {
                img.color = kopiWithMilkColor;
            }
        }
        else if (drink.drinkTeh >= 1)
        {
            img.color = tehColor;
            if (drink.milkEvaporated > 0)
            {
                img.color = tehWithMilkColor;
            }
        }
    }

    private void DrawCMilk(Drink drink)
    {
        cMilk.SetActive(drink.milkCondensed > 0);

    }
}
