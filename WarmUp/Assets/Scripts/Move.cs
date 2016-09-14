using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckKeyboardPress();
	}

	// Check what key on the keyboard that is being pressed
	void CheckKeyboardPress ()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			//move right
			this.gameObject.transform.position += new Vector3(1f, 0f, 0f);
		}
		else
		if (Input.GetKeyDown(KeyCode.A))
		{
			//move left
			this.gameObject.transform.position += new Vector3(-1f, 0f, 0f);
		}
		else
		if (Input.GetKeyDown(KeyCode.S))
		{
			//move down
			this.gameObject.transform.position += new Vector3(0f, -1f, 0f);
		}
		else
		if (Input.GetKeyDown(KeyCode.W))
		{
			//move up
			this.gameObject.transform.position += new Vector3(0f, 1f, 0f);
		}
	}
}
