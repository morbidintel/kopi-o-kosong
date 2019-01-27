using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class AuntieShoutController : MonoBehaviour
{
	public GameObject ShoutPrefab;

	// To determine the areas where the shout will spawn and the direction it flies
	public Vector2 SpawnPoint_min = new Vector2(20.0f, 0.0f);
	public Vector2 EndPoint_max = new Vector2(-5.0f, 3.6f);
	protected float yRange = 3.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

	public void SpawnAuntieShout(string text)
	{
		float xPos = SpawnPoint_min.x;
		float yPos = SpawnPoint_min.y;

		GameObject shoutObj = Instantiate(ShoutPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        shoutObj.transform.parent = null; 
        shoutObj.GetComponent<TextMeshPro>().text = text;

		xPos = EndPoint_max.x;
		yPos = EndPoint_max.y;

		shoutObj.transform.DOMove(new Vector3(xPos, yPos, 0f), 2);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
