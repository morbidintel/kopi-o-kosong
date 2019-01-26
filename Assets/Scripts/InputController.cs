using UnityEngine;
using System.Collections;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public GameObject unker;
    public PlayerDrink playerDrink;
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

	[Header("Ingredient Objects")]
	public GameObject kopi;
	public GameObject teh;
	public GameObject sugar;
	public GameObject condensed;
	public GameObject evaporated;
	public GameObject ice;

	[Header("Audio Clips")]
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
            playerDrink.drink.AddDrinkKopi();
            playClip(coffeeAndTeaClip);
			DOTween.Play(kopi);
			kopi.GetComponent<DOTweenPath>().DOPlay();
            Debug.Log("Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerDrink.drink.AddDrinkTeh();
            playClip(coffeeAndTeaClip);
			DOTween.Play(teh);
			teh.GetComponent<DOTweenPath>().DOPlay();
			Debug.Log("W");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            playerDrink.drink.AddSugar();
            playClip(sugarClip);
            Debug.Log("E");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            playerDrink.drink.AddMilkCondensed();
            playClip(milkClip);
			DOTween.Play(condensed);
			condensed.GetComponent<DOTweenPath>().DOPlay();
			Debug.Log("R");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerDrink.drink.AddMilkEvaporated();
            playClip(milkClip);
			DOTween.Play(evaporated);
			evaporated.GetComponent<DOTweenPath>().DOPlay();
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
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
    }
}
