using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	// designer variables
	public float speed;

	[HideInInspector]
	public Vector2 direction;

	private Vector2 movement;

	void start()
	{
		speed = 10;
		direction = Vector2.zero;
	}

	// Update is called once per frame
	void Update() 
	{
		movement = new Vector2(direction.x * speed, direction.y * speed);
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}
