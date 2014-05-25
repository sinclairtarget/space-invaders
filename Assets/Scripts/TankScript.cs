using UnityEngine;
using System.Collections;

public class TankScript : MonoBehaviour 
{
	public float leftBound;
	public float rightBound;

	private MoveScript moveScript;
	private WeaponScript weaponScript;

	public void Start()
	{
		moveScript = GetComponent<MoveScript>();
		weaponScript = GetComponentInChildren<WeaponScript>();

		if (leftBound > rightBound)
		{
			Debug.LogError("left bound greater than right bound!");
		}
	}

	public void Update()
	{
		HandleInput();

		// make sure that tanks stays on screen
		transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftBound, rightBound),
		                                 			 transform.position.y);
	}

	private void HandleInput()
	{
		// movement
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

		// firing
		if (Input.GetKey("space"))
		{
			weaponScript.Fire(new Vector2(0, 1));
		}
	}
}
