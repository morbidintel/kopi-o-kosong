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

    [SerializeField]
    UnityEvent onComplete;

    protected SpriteRenderer spriteRenderer;
    public Sprite[] characters = new Sprite[5];
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 5);
        spriteRenderer.sprite = characters[index];
        speech.SetActive(false);

		progressBar = GetComponentInChildren<ProgressBar>();
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
			transform.DOMoveY(.5f, 1f / loops)
					.SetLoops(loops - 2, LoopType.Yoyo)
					.SetDelay(loops % 2 == 1 ? 1f / loops / 2f : 0);
		}
    }

    public void RenderText()
    {
        // Do not render text when it is not the object in front
        if (transform.GetSiblingIndex() != 0)
            return;
        SetSpeech(true);
        ForceRenderText();
    }

    public void ForceRenderText()
    {
        SetSpeech(true);

        tmp.text = "I would like a " + drinkWanted + ".";

        Debug.Log(tmp.text);
        tmp.GetComponentInParent<VertexJitter>().StartAnim();
    }

    protected void SetSpeech(bool val)
    {
        tmp.GetComponent<MeshRenderer>().enabled = val;
        speech.SetActive(val);
        if (val)
        {
            speech.GetComponent<DOTweenAnimation>().DOPlay();
        }
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
        transform.DOMove(new Vector3(-10, 0, 0), 1).OnComplete(Kill);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}