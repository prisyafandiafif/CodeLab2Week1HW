﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public static UIManager instance;

	public Image timerBar;

	public Text scoreText;
	public Text highscoreText;

	// Use this for initialization
	void Awake ()
	{
		instance = this;

		//init
		highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		ResizeTimerBar();

		UpdateScoreText();
	}

	// Resize timer based on the current timer
	void ResizeTimerBar ()
	{
		timerBar.transform.localScale = new Vector3(GameManager.instance.timer/GameManager.instance.tempTimer, timerBar.transform.localScale.y, timerBar.transform.localScale.z);
	}

	// Update the score text
	void UpdateScoreText ()
	{
		scoreText.text = "" + GameManager.instance.score;
	}
}
