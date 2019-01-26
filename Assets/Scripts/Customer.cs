using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Drink> incomplete = new List<Drink>();
    public List<Drink> fulfilled = new List<Drink>();
    public float timeRemaining;
    public bool success;
    public DOTweenAnimation completeTween;

    public void Init(Difficulty difficulty, float timeLimit)
    {
        this.incomplete = difficulty.GenerateDrinkList();
        this.timeRemaining = timeLimit;
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
        completeTween.DOPlay();
    }

    void Update()
    {
        this.timeRemaining -= Time.deltaTime;
    }

    public void OnFinishTween()
    {
        Destroy(gameObject);
    }
}