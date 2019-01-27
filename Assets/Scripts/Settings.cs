using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	public static float EffectsVolume = 1.0f;
	public static float MusicVolume = 1.0f;

	[SerializeField]
	AudioSource bgMusic;

	// Start is called before the first frame update
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnEffectsVolumeChange(float value)
	{
		EffectsVolume = value;
	}

	public void OnMusicVolumeChange(float value)
	{
		MusicVolume = value;
		bgMusic.volume = MusicVolume;
	}
}
