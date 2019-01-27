using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public Drink drinkWanted;
    public float timeRemaining;
	protected float totalTime;
    public bool success;
	public bool isActiveCustomer;

    public TextMeshPro tmp;
    public GameObject speech;

	protected ProgressBar progressBar;
    protected SpriteRenderer[] progBarSprRenders;

    [SerializeField]
    UnityEvent onComplete;

    protected SpriteRenderer spriteRenderer;

    private bool hasRendered = false;

    public int angerLevel;
    public Sprite[] characters = new Sprite[5];
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 5);
        spriteRenderer.sprite = characters[index];
        speech.SetActive(false);

		progressBar = GetComponentInChildren<ProgressBar>();

        progBarSprRenders = progressBar.GetComponentsInChildren<SpriteRenderer>();
        ToggleProgressBar(false);
    }

    public void Init(Difficulty difficulty, float timeLimit)
    {
        drinkWanted = difficulty.GetDrink();
        timeRemaining = timeLimit;
		totalTime = timeLimit;
    }

    public bool SubmitDrink(Drink completedDrink)
    {
        return completedDrink.Equals(drinkWanted);
    }

    public void OnComplete()
    {
        onComplete.Invoke();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
		progressBar.setProgress(timeRemaining / totalTime);
    }

    public void OnFinishTween()
    {
        Destroy(gameObject);
    }

    // To remove all the text when auntie spawns
    public void ClearText()
    {
        tmp.text = "";
    }

    public void MoveTo(Vector3 location)
    {
        transform.DOMove(location, 1).OnComplete(RenderText);
        int loops = Mathf.Abs(Mathf.FloorToInt(location.x - transform.position.x)) / 2;
        if (loops > 2)
        {
			bool isOdd = loops % 2 == 1;
            transform.DOMoveY(.5f, 1f / loops)
					.SetLoops(isOdd ? loops - 4 : loops - 2, LoopType.Yoyo)
					.SetDelay(isOdd ? 1f / loops : 0);
        }
    }

    public void ToggleProgressBar(bool val)
    {
        for (int i = 0; i < progBarSprRenders.Length; i++)
        {
            progBarSprRenders[i].enabled = val;
        }
    }

    public void RenderText()
    {
        // Do not render text when it is not the object in front
        if (transform.GetSiblingIndex() != 0)
            return;
        ForceRenderText();
    }

    public void ForceRenderText()
    {
        hasRendered = true;
        SetSpeech(true);
        tmp.text = "I would like a " + drinkWanted + ".";

        Debug.Log(tmp.text);
        ToggleProgressBar(true);
        tmp.GetComponentInParent<VertexJitter>().StartAnim();
    }

    public void SetSpeech(bool val)
    {
        SetSpeechVisible(val);
        if (val)
        {
            speech.GetComponent<DOTweenAnimation>().DOPlay();
        }
    }

    public void SetSpeechVisible(bool val)
    {
        if (!hasRendered)
        {
            ForceRenderText();
            return;
        }
        speech.SetActive(val);
        tmp.GetComponent<MeshRenderer>().enabled = val;
    }

    protected void SetProgressBar(bool val) 
	{
		progressBar.gameObject.SetActive(false);
	}

    public void SetLayerOrder(int i)
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = i;
        speech.GetComponent<SpriteRenderer>().sortingOrder = i;
        tmp.sortingOrder = i;
    }

    public void Leave()
    {
        SetSpeech(false);
		SetProgressBar(false);
        transform.DOMove(new Vector3(-10, 0, 0), 1).OnComplete(Kill);
    }

    private void Kill()
    {
        if (gameObject) Destroy(gameObject);
    }

    public void PlayOnIncorrect()
    {
		timeRemaining -= Time.deltaTime * 500; // 10 seconds
        DOTween.Restart(gameObject, "shake");
		if (angerLevel >= 3) {
			GameController.Instance.timeRemaining -= 5f;
			timeRemaining = 0;
			CameraShake.Shake(0.5f,  0.5f);
			Leave();
		}
        else if (angerLevel >= 2)
        {
			DOTween.Restart(gameObject, "anger3");
            angerLevel++;
        }
        else if (angerLevel >= 1)
        {
            DOTween.Restart(gameObject, "anger2");
            angerLevel++;
        }
        else if (angerLevel >= 0)
        {
            DOTween.Restart(gameObject, "anger1");
            angerLevel++;
        }
    }
}