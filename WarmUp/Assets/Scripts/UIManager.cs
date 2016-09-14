using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public static UIManager instance;

	public Image timerBar;

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
		ResizeTimerBar();
	}

	// Resize timer based on the current timer
	void ResizeTimerBar ()
	{
		timerBar.transform.localScale = new Vector3(GameManager.instance.timer/GameManager.instance.tempTimer, timerBar.transform.localScale.y, timerBar.transform.localScale.z);
	}
}
