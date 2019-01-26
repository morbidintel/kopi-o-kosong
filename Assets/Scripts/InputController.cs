using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public GameObject unker;
    public PlayerDrink playerDrink;
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    public AudioClip coffeeAndTeaClip;
    public AudioClip milkClip;
    public AudioClip sugarClip;
    public AudioClip iceClip;
    public AudioClip serveClip;

    // Use this for initialization
    void Start()
    {
        playerDrink = unker.GetComponent("PlayerDrink") as PlayerDrink;
        gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
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
            playClip(sugarClip);
            Debug.Log("Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerDrink.drink.AddDrinkKopi();
            playClip(coffeeAndTeaClip);
            Debug.Log("W");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            playerDrink.drink.AddDrinkTeh();
            playClip(coffeeAndTeaClip);
            Debug.Log("E");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            playerDrink.drink.AddMilkCondensed();
            playClip(milkClip);
            Debug.Log("R");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerDrink.drink.AddMilkEvaporated();
            playClip(milkClip);
            Debug.Log("T");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            playerDrink.drink.AddIce();
            playClip(iceClip);
            Debug.Log("Y");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Empty Cup
            playerDrink.serve();
            playClip(serveClip);
            Debug.Log("Enter Key");
        }
    }
    public void playClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
    }
}
