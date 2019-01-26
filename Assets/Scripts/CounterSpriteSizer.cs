using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSpriteSizer : MonoBehaviour
{

	private Vector2 originalSize;
	private Vector2 originalScale;

	void Awake() {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		originalSize = spriteRenderer.sprite.bounds.size;
		originalScale = new Vector2(1, 1);

		float cameraHeight = Camera.main.orthographicSize * 2;
		Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
		Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

		Vector2 scale = new Vector2(1, 1);
		scale.x *= cameraSize.x / spriteSize.x;
		scale.y *= cameraSize.y / spriteSize.y / 2;

		transform.position = Vector2.zero + new Vector2(0, Camera.main.transform.position.y - Camera.main.orthographicSize / 2);
		transform.localScale = scale;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
