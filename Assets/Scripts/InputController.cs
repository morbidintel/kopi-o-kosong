using System.Collections;
using DG.Tweening;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject unker;
    public PlayerDrink playerDrink;
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    [SerializeField] private GameObject pausePanel;

    [Header("Ingredient Objects")]
	public GameObject kopi;
	public GameObject teh;
	public GameObject sugar;
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
        pausePanel.SetActive(false);
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
            playerDrink.empty();
            Debug.Log("Escape pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            playerDrink.drink.AddDrinkKopi();
            playClip(coffeeAndTeaClip);
			DOTween.Play(kopi);
			var path = kopi.GetComponent<DOTweenPath>();
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(kopi); });
			path.DOPlay();
            Debug.Log("Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerDrink.drink.AddDrinkTeh();
            playClip(coffeeAndTeaClip);
			DOTween.Play(teh);
			var path = teh.GetComponent<DOTweenPath>();
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(teh); });
			path.DOPlay();
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
			var path = condensed.GetComponent<DOTweenPath>();
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(condensed); });
			path.DOPlay();
			Debug.Log("R");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerDrink.drink.AddMilkEvaporated();
            playClip(milkClip);
			DOTween.Play(evaporated);
			var path = evaporated.GetComponent<DOTweenPath>();
			path.onComplete.AddListener(() => { path.DOPlayBackwards(); DOTween.PlayBackwards(evaporated); });
			path.DOPlay();
			Debug.Log("T");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            playerDrink.drink.AddIce();
            playClip(iceClip);
			iceCubes.SetActive(true);
			iceCubes.GetComponent<DOTweenPath>().DOPlay();
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
