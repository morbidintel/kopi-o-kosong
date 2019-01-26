using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public GameObject unker;
    public PlayerDrink playerDrink;

    // Use this for initialization
    void Start()
    {
        playerDrink = unker.GetComponent("PlayerDrink") as PlayerDrink;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Empty Cup
            playerDrink.empty();
            Debug.Log("Escape pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            playerDrink.drink.AddSugar();

            Debug.Log("Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerDrink.drink.AddDrinkKopi();

            Debug.Log("W");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            playerDrink.drink.AddDrinkTeh();
            Debug.Log("E");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            playerDrink.drink.AddMilkCondensed();
            Debug.Log("R");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerDrink.drink.AddMilkEvaporated();
            Debug.Log("T");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            playerDrink.drink.AddIce();
            Debug.Log("Y");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // Empty Cup
            playerDrink.serve();
            Debug.Log("Enter Key");
        }
    }
}
