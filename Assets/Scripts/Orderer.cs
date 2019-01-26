using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour
{

    private float t;
    private List<Drink> orders;

    public GameObject cup;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.time + 60;
    }

    // Update is called once per frame
    void Update()
    {
        //should this be here? InputController
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Empty Cup
            Debug.Log("Escape pressed");
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            
            Debug.Log("Q");
        } else if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W");
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("E");
        } else if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R");
        } else if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("T");
        } else if (Input.GetKeyDown(KeyCode.Y)) {
            Debug.Log("Y");
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            // Empty Cup
            Debug.Log("Enter Key");
        }   
    }

    void GenerateOrder()
    {
        orders.Add(new Drink());
    }

    void UpdateTimeForNextOrder()
    {
        t = Time.time + 30 + Random.value * 30; //30 to 60 seconds.
    }
}
