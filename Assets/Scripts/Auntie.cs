using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using UnityEngine.Events;

public class Auntie : MonoBehaviour
{
    public Drink drinkWanted;
    public float timeRemaining;
    protected float totalTime;
    public bool success;
    public bool isActiveCustomer;

    public TextMeshPro tmp;
    public GameObject speech;

    protected ProgressBar progressBar;
    protected SpriteRenderer[] progBarSprRenders;

    protected SpriteRenderer spriteRenderer;

    private bool hasRendered = false;

    public int angerLevel;
    public Sprite[] characters = new Sprite[5];
    private Difficulty difficulty;

    public GameObject[] AuntieShout = new GameObject[2];

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 1);
        spriteRenderer.sprite = characters[index];

        progressBar = GetComponentInChildren<ProgressBar>();
    }

    public Auntie(Difficulty difficulty, float timeLimit, Drink drinkWanted)
    {
        // Summon Scream
        // Instantiate(AuntieShout[Random.Range(0, 2)], transform).GetComponent<TextMeshPro>().text = "Hello";
    }

    public void Init(Difficulty difficulty, float timeLimit, Drink drinkWanted)
    {
        timeRemaining = timeLimit;
        totalTime = timeLimit;
        this.drinkWanted = drinkWanted;
    }

    // Override
    public bool SubmitDrink(Drink completedDrink)
    {
        return completedDrink.Equals(drinkWanted);
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
        speech.SetActive(val);
        tmp.GetComponent<MeshRenderer>().enabled = val;
    }

    protected void SetProgressBar(bool val)
    {
        progressBar.gameObject.SetActive(false);
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
        if (angerLevel >= 3)
        {
            timeRemaining = 0;
            CameraShake.Shake(0.5f, 0.5f);
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