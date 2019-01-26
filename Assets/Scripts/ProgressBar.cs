using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
	public GameObject holder;
	public GameObject bar;
	private float originalScaleX;
    // Start is called before the first frame update
    void Start()
    {
		originalScaleX = holder.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
    }

	/**
	 * Progress - 0.0f to 1.0f
	 */
	public void setProgress(float progress) 
	{
		if (progress >= 0.5f) bar.GetComponent<SpriteRenderer>().color = new Color((1.0f - progress) * 2.0f, 1.0f, 0.0f, 1.0f);
		else bar.GetComponent<SpriteRenderer>().color = new Color(1.0f, progress * 2.0f, 0.0f, 1.0f);

		if (progress <= 0.0f)
			holder.transform.localScale = new Vector3(0.0f, 
				holder.transform.localScale.y, holder.transform.localScale.z);
		else 
			holder.transform.localScale = new Vector3(originalScaleX * progress, 
				holder.transform.localScale.y, holder.transform.localScale.z);
	}
}
