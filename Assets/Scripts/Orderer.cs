using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;
using System.Linq;

public class Orderer : Singleton<Orderer>
{
    private List<Customer> orders = new List<Customer>();
    private Auntie auntie;

    public GameObject customerPrefab;
	public GameObject auntiePrefab;
    public GameObject finalDestination;
	public GameObject auntieDestination;
    public GameObject gameController;
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip correctAudioClip;
	public AudioClip incorrectAudioClip;

    private bool auntieDelay = false;


    private Vector3 offset = new Vector3(1f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
		gameObject.AddComponent<AudioSource>();
		auntie = null;
        StartCoroutine(AuntieCoroutine());
        StartCoroutine(OrderCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
		int removed = orders.RemoveAll(c => c.timeRemaining < 0f);
		if (removed > 0)
		{
			//@todo: penalty
		}
	}

    IEnumerator AuntieCoroutine()
    {
        while (true)
        {
            Difficulty difficulty = gameController.GetComponent<GameController>().difficulty;
			if (auntie == null && auntieDelay) GenerateAuntie(difficulty);
            auntieDelay = true;
            yield return new WaitForSeconds((5 - difficulty.stageDifficulty) * 3 + 10);
        }
    }

    IEnumerator OrderCoroutine()
    {
        while (true)
        {
            Difficulty difficulty = gameController.GetComponent<GameController>().difficulty;
            GenerateOrder(difficulty);
            yield return new WaitForSeconds((5 - difficulty.stageDifficulty) * 2);
        }
    }

    public void checkAndScoreDrink(Drink drink)
    {
		Customer active = orders[0];
        // Fill aunty's orders first!!!!
        if (auntie != null)
        {
			Debug.Log("Serve Auntie");
            if (auntie.SubmitDrink(drink))
            {
				Debug.Log("Serve Auntie  CORRECT");
                // SCORE!
				playClip(correctAudioClip);
				gameController.GetComponent<GameController>().AddScore((int)Mathf.Floor(active.timeRemaining));
				auntie.angerLevel = 0;
				auntie.OnComplete();
				auntie.Leave();
                auntie = null;
                // Render unker's orders
                active.SetSpeechVisible(true);
            }
            return;
        }
        if (active.SubmitDrink(drink))
        {
			playClip(correctAudioClip);
            gameController.GetComponent<GameController>().AddScore((int)Mathf.Floor(active.timeRemaining));
            active.angerLevel = 0;
			active.OnComplete();
            active.Leave();
            ProcessQueue();
            return;
        }
		PlayIncorrectOrder(active);
        // If not fulfilled, do something
        //todo: penalty
    }

	void PlayIncorrectOrder(Customer active) {
		audioSource.volume = 1;
		active.PlayOnIncorrect();
		playClip(incorrectAudioClip);
	}

	public void playClip(AudioClip audioClip)
	{
		audioSource.Stop();
		audioSource.clip = audioClip;
		audioSource.PlayOneShot(audioClip);
	}

    void GenerateOrder(Difficulty stageDifficulty)
    {
        Customer cust = Instantiate(customerPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity, transform).GetComponent<Customer>();
        cust.Init(stageDifficulty, 60.0f);
        int positionInQueue = orders.Count();
        cust.SetLayerOrder(999 - positionInQueue);
        cust.MoveTo(finalDestination.transform.position + offset * positionInQueue);
        orders.Add(cust);
    }

    void ProcessQueue()
    {
        orders.RemoveAt(0);
        for (int i = 0; i < orders.Count(); i++)
        {
            Customer cust = orders[i];
            cust.MoveTo(finalDestination.transform.position + offset * i);
            cust.SetLayerOrder(999 - i);
        }
        if (orders.Any())
        {
            Customer activeCustomer = orders[0].GetComponent<Customer>();
            activeCustomer.ForceRenderText();
        }
    }

    void GenerateAuntie(Difficulty stageDifficulty)
    {
		// Generate auntie flying text

		// Coroutine
		// Generate auntie 3s later
		Debug.Log("Auntie Generated");
		var threshold = 0.5f * stageDifficulty.stageDifficulty + 0.25f;
		if (Random.Range(0f, 1f) < threshold) 
		{
			auntie = Instantiate(auntiePrefab, new Vector3(10f, 0f, 0f), Quaternion.identity, transform).GetComponent<Auntie>();
			auntie.Init(stageDifficulty, Random.Range(5,10));

			auntie.MoveTo(auntieDestination.transform.position);

			// Auntie is priority
			if (orders.Count > 0) orders[0].SetSpeech(false);
		}
    }
}
