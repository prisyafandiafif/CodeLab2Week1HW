using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance;

	public AudioSource sfxArrange;
	public AudioSource sfxSwap;
	public AudioSource sfxBump;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Play SFX
	public void PlaySFX (AudioSource sfx)
	{
		sfx.Play();
	}
}
