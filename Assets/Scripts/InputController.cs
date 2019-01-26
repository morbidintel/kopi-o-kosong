using System.Collections;
using DG.Tweening;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public GameObject unker;
	public PlayerDrink playerDrink;
	private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
	[SerializeField] private GameObject pausePanel;

    public GameObject cup;

    [Header("Ingredient Objects")]
	public GameObject kopi;
	public GameObject teh;
	public GameObject sugarSpoon;
	public GameObject condensed;
	public GameObject evaporated;
	public GameObject iceCubes;

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
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (!pausePanel.activeInHierarchy)
			{
				Pause();
			}
			else if (pausePanel.activeInHierarchy)
			{
				Continue();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			// Empty Cup
			playerDrink.Empty();
			Debug.Log("Escape pressed");
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			var path = kopi.GetComponent<DOTweenPath>();
			if (path.GetTween().IsPlaying()) return; // don't register if anim is playing

			playerDrink.drink.AddDrinkKopi();
			playClip(coffeeAndTeaClip);
			DOTween.Play(kopi);
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(kopi); });
			path.DORestart();
			Debug.Log("Q");
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			var path = teh.GetComponent<DOTweenPath>();
			if (path.GetTween().IsPlaying()) return; // don't register if anim is playing

			playerDrink.drink.AddDrinkTeh();
			playClip(coffeeAndTeaClip);
			DOTween.Play(teh);
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(teh); });
			path.DORestart();
			Debug.Log("W");
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			var path = sugarSpoon.GetComponent<DOTweenPath>();
			if (path.GetTween().IsPlaying()) return; // don't register if anim is playing

			playerDrink.drink.AddSugar();
			playClip(sugarClip);
			DOTween.Play(sugarSpoon);
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(sugarSpoon); });
			path.DORestart();
			Debug.Log("E");
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			var path = condensed.GetComponent<DOTweenPath>();
			if (path.GetTween().IsPlaying()) return; // don't register if anim is playing

			playerDrink.drink.AddMilkCondensed();
			playClip(milkClip);
			DOTween.Play(condensed);
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(condensed); });
			path.DORestart();
			Debug.Log("R");
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
			var path = evaporated.GetComponent<DOTweenPath>();
			if (path.GetTween().IsPlaying()) return; // don't register if anim is playing

			playerDrink.drink.AddMilkEvaporated();
			playClip(milkClip);
			DOTween.Play(evaporated);
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(evaporated); });
			path.DORestart();
			Debug.Log("T");
		}
		else if (Input.GetKeyDown(KeyCode.Y))
		{
			var path = iceCubes.GetComponent<DOTweenPath>();
			if (iceCubes.activeSelf && path.GetTween().IsPlaying()) return; // don't register if anim is playing
			// don't care if there's already ice in cup

			playerDrink.drink.AddIce();
			playClip(iceClip);
			iceCubes.SetActive(true);
			path.DOPlay();
			Debug.Log("Y");
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			// Serve Cup
			playerDrink.Serve();
			playClip(serveClip);
			Debug.Log("Enter Key");
		}
        playerDrink.RenderDrink();
	}

	public void playClip(AudioClip audioClip)
	{
		audioSource.Stop();
		audioSource.clip = audioClip;
		audioSource.PlayOneShot(audioClip);
	}

	private void Pause()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}

	private void Continue()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
}
