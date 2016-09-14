using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;

	// To store gameobjects of Dot
	public GameObject[] dots;

	// To store a gameobject that contains the arrangement of each dot on the screen
	public GameObject dotsContainer;

	// To store the amount of row and column
	public int rowAmount;
	public int columnAmount;

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
				int randomIDForDots = Random.Range(0, 4);
	
				GameObject newDot = Instantiate(dots[randomIDForDots]);
	
				//make it a parent of dotsContainer
				newDot.transform.parent = dotsContainer.transform;
	
				//position it
				newDot.transform.position = new Vector3((-Mathf.FloorToInt(rowAmount*1f/2f)*1f) + (1f*i), (Mathf.FloorToInt(columnAmount*1f/2f)*1f) - (1f*j), newDot.transform.position.z);
	
				//show it on screen
				newDot.SetActive(true);
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
}
