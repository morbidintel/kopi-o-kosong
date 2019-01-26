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
	public List<Drink> incomplete = new List<Drink>();
	public List<Drink> fulfilled = new List<Drink>();
	public float timeRemaining;
	public bool success;
    public bool isActiveCustomer;

    public TextMeshPro tmp;
    public GameObject speech;

    [SerializeField]
	UnityEvent onComplete;

	SpriteRenderer spriteRenderer;
	public Sprite[] characters = new Sprite[5];
	public void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		int index = Random.Range(0, 5);
		spriteRenderer.sprite = characters[index];
        speech.SetActive(false);
    }

	public void Init(Difficulty difficulty, float timeLimit)
	{
		incomplete = difficulty.GenerateDrinkList();
		timeRemaining = timeLimit;
    }

	public bool SubmitDrink(Drink completedDrink)
	{
		foreach (Drink drink in incomplete)
		{
			if (drink.Equals(completedDrink))
			{
				incomplete.Remove(drink);
				fulfilled.Add(drink);
				return true;
			}
		}
		return false;
	}

	public bool IsCompleted()
	{
		return (incomplete.Count == 0);
	}

	public void OnComplete()
	{
		onComplete.Invoke();
	}

	void Update()
	{
		timeRemaining -= Time.deltaTime;
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
    }

    public void RenderText()
    {
		// Do not render text when it is not the object in front
		if (transform.GetSiblingIndex() != 0)
			return;
        setSpeech(true);
        ForceRenderText();
    }

	public void ForceRenderText()
    {
        List<string> incompleteDrinks = new List<string>();
        List<string> completeDrinks = new List<string>();
        setSpeech(true);

        foreach (Drink drink in incomplete)
        {
            incompleteDrinks.Add(drink.ToString());
        }
        string incompleteDrinksStr = "<b>" + string.Join(", ", incompleteDrinks.ToArray());
        incompleteDrinksStr += "</b>";

        foreach(Drink drink in fulfilled)
        {
            completeDrinks.Add(drink.ToString());
        }
        string completeDrinkStr = "<s>" + string.Join(", ", completeDrinks.ToArray());
        completeDrinkStr += "</s>";

        string text = "I would like a " + incompleteDrinksStr + completeDrinkStr;

        tmp.text = text + ".";
		Debug.Log(tmp.text);
        tmp.GetComponentInParent<VertexJitter>().StartAnim();
    }

    private void setSpeech(bool val)
    {
        tmp.GetComponent<MeshRenderer>().enabled = val;
        speech.SetActive(val);
    }

    public void SetLayerOrder(int i)
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = i;
        speech.GetComponent<SpriteRenderer>().sortingOrder = i;
        tmp.sortingOrder = i;
    }

    public void Leave()
    {
        setSpeech(false);
        transform.DOMove(new Vector3(-15, 0, 0), 1).OnComplete(Kill);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}