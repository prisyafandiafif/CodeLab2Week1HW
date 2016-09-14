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
		//to move right
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
		//to move left
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
		//to move up
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
		//to move down
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
		//to rotate
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (
				(
				isHorizontal 
				&&
				(
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+1, this.gameObject.transform.position.z))
			 	&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-1, this.gameObject.transform.position.z))
				)	
				)
				||
				(
				!isHorizontal 
				&&
				(
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x+1, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
			 	&&
				GameManager.instance.IsDotExistOnPosition(new Vector3(this.gameObject.transform.position.x-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z))
				)	
				)
			   )
			{ 
				//rotate
				this.gameObject.transform.eulerAngles += new Vector3(0f, 0f, -90f);
	
				isHorizontal = !isHorizontal;
			}
		}
		//to swap dots
		else
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (isHorizontal)
			{ 
				GameObject rightDot = GameManager.instance.DotOnPosition(new Vector3(this.gameObject.transform.position.x+1, this.gameObject.transform.position.y, this.gameObject.transform.position.z)).associatedGameObject;
				GameObject leftDot = GameManager.instance.DotOnPosition(new Vector3(this.gameObject.transform.position.x-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z)).associatedGameObject;
			
				if (rightDot != null && leftDot != null)
				{
					Debug.Log("Swap " + rightDot.name + " with " + leftDot.name);

					//swap dots
					rightDot.transform.position += new Vector3(-2f, 0f, 0f);
					leftDot.transform.position += new Vector3(2f, 0f, 0f);

					//always check the arrangement of dots
					GameManager.instance.CheckArrangementOfDots();
				}
			}
			//otherwise
			else
			{
				GameObject upDot = GameManager.instance.DotOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+1, this.gameObject.transform.position.z)).associatedGameObject;
				GameObject downDot = GameManager.instance.DotOnPosition(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-1, this.gameObject.transform.position.z)).associatedGameObject;
			
				if (upDot != null && downDot != null)
				{
					Debug.Log("Swap " + upDot.name + " with " + downDot.name);

					//swap dots
					upDot.transform.position += new Vector3(0f, -2f, 0f);
					downDot.transform.position += new Vector3(0f, 2f, 0f);

					//always check the arrangement of dots
					GameManager.instance.CheckArrangementOfDots();
				}
			}
		}
	}
}
