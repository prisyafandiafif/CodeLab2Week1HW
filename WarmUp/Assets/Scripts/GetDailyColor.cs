using UnityEngine;
using System;
using System.Collections;

public class GetDailyColor : GetColor 
{

	// Use this for initialization
	void Start () 
	{
		int dayOfYear = DateTime.Now.DayOfYear;
	
		UnityEngine.Random.InitState(dayOfYear);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
