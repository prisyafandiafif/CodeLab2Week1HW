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

	// To store the score
	public int score;

	// Added score
	public int addedScore;

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
	}

	// Init random dots
	public void InitDots ()
	{
		for (int j = 0; j < columnAmount; j++)
		{
			for (int i = 0; i < rowAmount; i++)
			{
				GenerateDot(new Vector2((-Mathf.FloorToInt(rowAmount*1f/2f)*1f) + (1f*i), (Mathf.FloorToInt(columnAmount*1f/2f)*1f) - (1f*j)));
			}
		}

		//always check the arrangement of dots
		CheckArrangementOfDots();
	}

	// Generate a dot at a certain position
	public void GenerateDot (Vector2 pos)
	{
		int randomIDForDots = Random.Range(0, dotsDefault.Length);
	
		GameObject newDot = Instantiate(dotsDefault[randomIDForDots]);
	
		//make it a parent of dotsContainer
		newDot.transform.parent = dotsContainer.transform;
	
		//position it
		newDot.transform.position = new Vector3(pos.x, pos.y, newDot.transform.position.z);
	
		//show it on screen
		newDot.SetActive(true);

		//add to list of dot class
		Dot toPutDot = new Dot();
		toPutDot.colorID = randomIDForDots;
		toPutDot.associatedGameObject = newDot;
		dots.Add(toPutDot);
	}

	// Count timer
	public void CountTimer ()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
		//when time's up
		else
		{
			CheckHighscore();

			//restart the game
			Application.LoadLevel(Application.loadedLevel);
		}
	}	
	
	// Check Highscore
	public void CheckHighscore ()
	{
		if (score > PlayerPrefs.GetInt("Highscore"))
		{
			PlayerPrefs.SetInt("Highscore", score);
		}
	}

	// Check arrangement of dots
	public void CheckArrangementOfDots ()
	{
		for (int i = 0; i < dots.Count; i++)
		{
			if (dots[i].associatedGameObject.activeSelf &&
				DotMakeAnArrangement(dots[i]) > 0)
			{
				score += addedScore;
			}
		}
	}

	// Check to which direction the arrangement is made. 0 if none, 1 if upward, 2 if to the right, 3 if downward, 4 if to the left, 5 if vertical middle, 6 if horizontal middle
	public int DotMakeAnArrangement (Dot dot) 
	{
		//check dots upward
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+1, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+2, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot up1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+1, dot.associatedGameObject.transform.position.z));
			Dot up2Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+2, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				==
				up1Dot.colorID
				&&
				dot.colorID 
				==
				up2Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots upward!");

				up1Dot.associatedGameObject.SetActive(false);
				up2Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(up1Dot.associatedGameObject.transform.position);
				GenerateDot(up2Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 1;
			}
		}

		//check dots downward
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-1, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-2, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot down1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-1, dot.associatedGameObject.transform.position.z));
			Dot down2Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-2, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				==
				down1Dot.colorID
				&&
				dot.colorID 
				==
				down2Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots downward!");

				down1Dot.associatedGameObject.SetActive(false);
				down2Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(down1Dot.associatedGameObject.transform.position);
				GenerateDot(down2Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 3;
			}
		}

		//check dots to the left
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-2, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot left1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));
			Dot left2Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-2, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				== 
				left1Dot.colorID
				&&
				dot.colorID 
				==
				left2Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots to the left!");

				left1Dot.associatedGameObject.SetActive(false);
				left2Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(left1Dot.associatedGameObject.transform.position);
				GenerateDot(left2Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 4;
			}
		}

		//check dots to the right
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+2, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot right1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));
			Dot right2Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+2, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				==
				right1Dot.colorID
				&&
				dot.colorID 
				==
				right2Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots to the right!");

				right1Dot.associatedGameObject.SetActive(false);
				right2Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(right1Dot.associatedGameObject.transform.position);
				GenerateDot(right2Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 2;
			}
		}

		//check dots middle horizontal
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot right1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x+1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));
			Dot left1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x-1, dot.associatedGameObject.transform.position.y, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				==
				right1Dot.colorID
				&&
				dot.colorID 
				==
				left1Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots middle horizontal!");

				right1Dot.associatedGameObject.SetActive(false);
				left1Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(right1Dot.associatedGameObject.transform.position);
				GenerateDot(left1Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 6;
			}
		}

		//check dots middle vertical
		if (
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+1, dot.associatedGameObject.transform.position.z))
			&&
			IsDotExistOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-1, dot.associatedGameObject.transform.position.z))
		   )
		{
			Dot up1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y+1, dot.associatedGameObject.transform.position.z));
			Dot down1Dot = DotOnPosition(new Vector3(dot.associatedGameObject.transform.position.x, dot.associatedGameObject.transform.position.y-1, dot.associatedGameObject.transform.position.z));

			if (dot.colorID 
				==
				up1Dot.colorID
				&&
				dot.colorID 
				==
				down1Dot.colorID
			   )
			{
				Debug.Log("Make an arrangement of dots middle vertical!");

				up1Dot.associatedGameObject.SetActive(false);
				down1Dot.associatedGameObject.SetActive(false);
				dot.associatedGameObject.SetActive(false);

				//generate a new dot
				GenerateDot(up1Dot.associatedGameObject.transform.position);
				GenerateDot(down1Dot.associatedGameObject.transform.position);	
				GenerateDot(dot.associatedGameObject.transform.position);

				return 5;
			}
		}

		return 0;
	}
	
	// To check whether there is a dot on the given position or not
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

	// Return a gameobjet on a certain position
	public Dot DotOnPosition (Vector3 positionToCheck)
	{
		for (int i = 0; i < dots.Count; i++)
		{
			if (dots[i].associatedGameObject.activeSelf &&
				positionToCheck.x > dots[i].associatedGameObject.transform.position.x - 0.1f &&
				positionToCheck.x < dots[i].associatedGameObject.transform.position.x + 0.1f &&
				positionToCheck.y > dots[i].associatedGameObject.transform.position.y - 0.1f &&
				positionToCheck.y < dots[i].associatedGameObject.transform.position.y + 0.1f)
			{
				return dots[i];
			}
		}

		return null;
	}
}
