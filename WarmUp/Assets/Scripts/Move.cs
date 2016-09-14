using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	// To store the currnet orientation of the selector
	public bool isHorizontal;

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
			if (
				(
				isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x+2, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
				) 
				||
				(
				!isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x+1, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
				)
			   )
			{
				//move right
				this.gameObject.transform.position += new Vector3(1f, 0f, 0f);
			}
		}
		else
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (
				(
				isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x-2, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
				) 
				||
				(
				!isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
				)
			   )
			{
				//move left
				this.gameObject.transform.position += new Vector3(-1f, 0f, 0f);
			}
		}
		else
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (
				(
				isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-1, this.gameObject.transform.position.z))
				) 
				||
				(
				!isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-2, this.gameObject.transform.position.z))
				)
			   )
			{
				//move down
				this.gameObject.transform.position += new Vector3(0f, -1f, 0f);
			}
		}
		else
		if (Input.GetKeyDown(KeyCode.W))
		{
			if (
				(
				isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+1, this.gameObject.transform.position.z))
				) 
				||
				(
				!isHorizontal
				&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+2, this.gameObject.transform.position.z))
				)
			   )
			{
				//move up
				this.gameObject.transform.position += new Vector3(0f, 1f, 0f);
			}
		}
		else
		if (Input.GetKeyDown(KeyCode.X))
		{
			//rotate
			this.gameObject.transform.eulerAngles += new Vector3(0f, 0f, -90f);

			isHorizontal = !isHorizontal;
		}
	}
}
