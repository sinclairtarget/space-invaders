using UnityEngine;
using System.Collections;

public class TankScript : MonoBehaviour 
{
	private MoveScript moveScript;

	public void Start()
	{
		moveScript = GetComponent<MoveScript>();
	}

	public void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		if (Input.GetKey("left"))
		{
			moveScript.direction = new Vector2(-1, 0);
		}
		else if (Input.GetKey("right"))
		{
			moveScript.direction = new Vector2(1,0);
		}
		else
		{
			moveScript.direction = Vector2.zero;
		}
	}
}
