using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	// To store gameobjects of Dot
	public GameObject[] dots;

	// To store a gameobject that contains the arrangement of each dot on the screen
	public GameObject dotsContainer;

	// To store the amount of row and column
	public int rowAmount;
	public int columnAmount;

	// Use this for initialization
	void Start () 
	{
		//init random dots on screen;
		InitDots();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Init random dots
	public void InitDots ()
	{
		for (int i = 0; i < rowAmount; i++)
		{
			int randomIDForDots = Random.Range(0, 4);

			GameObject newDot = Instantiate(dots[randomIDForDots]);

			//make it a parent of dotsContainer
			newDot.transform.parent = dotsContainer.transform;

			//position it
			//newDot.transform.position = new Vector3(, newDot.transform.position.y, newDot.transform.position.z);

			//show it on screen
			newDot.SetActive(true);
		}
	}
}
