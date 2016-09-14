using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
// A class to hold information of each dot
public class Dot	 
{
	//1 for red, 2 for green, 3 for blue, 4 for yellow
	public int colorID; 

	//associated GameObject of dots in the gameplay
	public GameObject associatedGameObject;
}

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;

	// To store default gameobjects of Dot
	public GameObject[] dotsDefault;

	// To store a gameobject that contains the arrangement of each dot on the screen
	public GameObject dotsContainer;

	// To store the amount of row and column
	public int rowAmount;
	public int columnAmount;

	// To store classes of Dot
	public List<Dot> dots = new List<Dot>();

	// To store timer infomration in seconds
	public float timer;
	[HideInInspector] public float tempTimer;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	void Start () 
	{
		//init
		tempTimer = timer;

		//init random dots on screen;
		InitDots();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// always count down the timer
		CountTimer();

		// always check the arrangement of dots
		CheckArrangementOfDots();
	}

	// Init random dots
	public void InitDots ()
	{
		for (int j = 0; j < columnAmount; j++)
		{
			for (int i = 0; i < rowAmount; i++)
			{
				int randomIDForDots = Random.Range(0, dotsDefault.Length);
	
				GameObject newDot = Instantiate(dotsDefault[randomIDForDots]);
	
				//make it a parent of dotsContainer
				newDot.transform.parent = dotsContainer.transform;
	
				//position it
				newDot.transform.position = new Vector3((-Mathf.FloorToInt(rowAmount*1f/2f)*1f) + (1f*i), (Mathf.FloorToInt(columnAmount*1f/2f)*1f) - (1f*j), newDot.transform.position.z);
	
				//show it on screen
				newDot.SetActive(true);

				//add to list of dot class
				Dot toPutDot = new Dot();
				toPutDot.colorID = randomIDForDots;
				toPutDot.associatedGameObject = newDot;
				dots.Add(toPutDot);
			}
		}
	}

	// Count timer
	public void CountTimer ()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
	}	
	
	// Check arrangement of dots
	public void CheckArrangementOfDots ()
	{

	}

	public bool IsDotExistOnPosition (Vector3 positionToCheck)
	{
		for (int i = 0; i < dots.Count; i++)
		{
			if (dots[i].associatedGameObject.activeSelf &&
				positionToCheck.x > dots[i].associatedGameObject.transform.position.x - 0.1f &&
				positionToCheck.x < dots[i].associatedGameObject.transform.position.x + 0.1f &&
				positionToCheck.y > dots[i].associatedGameObject.transform.position.y - 0.1f &&
				positionToCheck.y < dots[i].associatedGameObject.transform.position.y + 0.1f)
			{
				return true;
			}
		}

		return false;
	}
}
