using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	[SerializeField] GameObject transitionPane; //for fades, will enable when scene change
	[SerializeField] float delay = 0.0f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator LoadSceneCorot(string scname, int idx)
	{
		yield return new WaitForEndOfFrame();
		if (transitionPane)
		{
			transitionPane.SetActive(true);
		}
		yield return new WaitForSeconds(delay);
		Resources.UnloadUnusedAssets();
		if (scname != "")
		{
			SceneManager.LoadScene(scname);
		}
		else
		{
			SceneManager.LoadScene(idx);
		}
	}

	public void LoadSceneByIndex(int index)
	{
		StartCoroutine(LoadSceneCorot("", index));
	}

	public void LoadSceneByName(string scname)
	{
		StartCoroutine(LoadSceneCorot(scname, 0));
	}

	public void Quit()
	{
#if UNITY_STANDALONE
		Application.Quit();
#endif
	}
}
