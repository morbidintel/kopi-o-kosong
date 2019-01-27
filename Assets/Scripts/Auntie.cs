using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class Auntie : Customer
{
    // Start is called before the first frame update
    public Drink requestedDrink;

    private int numOfDrinkCompleted = 0;
    private int numOfDrinkToDo;
    private Difficulty difficulty;
    public int randomNumOfDrink = 2;
    bool auntiePresent;

    public GameObject[] AuntieShout = new GameObject[2];

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 1);
        spriteRenderer.sprite = characters[index];
		auntiePresent = true;

        progressBar = GetComponentInChildren<ProgressBar>();
    }

    public Auntie(Difficulty difficulty, float timeLimit)
    {
        this.requestedDrink = difficulty.GetDrink();
        this.timeRemaining = timeLimit;
        numOfDrinkToDo = Random.Range(0, randomNumOfDrink);

        this.difficulty = difficulty;

        // Summon Scream
        Instantiate(AuntieShout[Random.Range(0, 2)], transform).GetComponent<TextMeshPro>().text = "Hello";
    }

    // Override
    public bool SubmitDrink(Drink completedDrink)
    {
        return completedDrink.Equals(drinkWanted);
    }

    public bool IsAuntieFinished()
    {
        if (numOfDrinkCompleted < numOfDrinkToDo)
        {
            // Reset drink here
            this.requestedDrink = difficulty.GetDrink();
            ClearText();
            ForceRenderText();
            return false;
        }

        return true;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        progressBar.setProgress(timeRemaining / totalTime);
        if (auntiePresent && (timeRemaining <= 0))	
        {
            CameraShake.Shake(0.5f, 0.5f);
            auntiePresent = false;
            Leave();
        }
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
        // RENDER CAUSE ITS AUNTIE
        SetSpeech(true);
        ForceRenderText();
    }

    public void ForceRenderText()
    {
        List<string> incompleteDrinks = new List<string>();
        List<string> completeDrinks = new List<string>();
        SetSpeech(true);

        tmp.text = drinkWanted + " PLS";

        Debug.Log(tmp.text);
        tmp.GetComponentInParent<VertexJitter>().StartAnim();
    }


}	