using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// enemy array needs to handle movement, firing, call animate
// immediate children are column objects
// TODO handle deletions

public class EnemyArrayScript : MonoBehaviour
{
	// movement variables
	public float leftBound;
	public float rightBound;
	public float dropDistance;
	public float shiftDistance;
	public float shiftSpeed; // shifts per second
	public float speedUpRatio; 

	// firing variables
	public float maxFiringRate; // shots per second

	private float shiftTime;
	private float shiftPeriod;
	private Vector2 shiftDirection;
	private bool turning;

	private float firingTime;
	private float maxFiringPeriod;

	// Use this for initialization
	void Start() 
	{
		shiftPeriod = 1 / shiftSpeed;
		shiftTime = shiftPeriod;
		shiftDirection = new Vector2(1, 0);

		maxFiringPeriod = 1 / maxFiringRate;
		firingTime = maxFiringPeriod;

		turning = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (shiftTime <= 0)
		{
			MoveArray();
			Animate(); // if we've shifted, we need to animate
			shiftTime = shiftPeriod;
		}

		if (firingTime <= 0)
		{
			FireSomewhere();

			firingTime = UnityEngine.Random.Range(maxFiringPeriod * 0.8f, maxFiringPeriod);
		}

		shiftTime -= Time.deltaTime;
		firingTime -= Time.deltaTime;
	}

	private void MoveArray()
	{
		// change direction at edges and drop
		// needs one update to drop (in that update there should be no x movement)
		// needs another update to move back in toward the center of the screen (it will still be past bounds here)
		if (transform.position.x >= rightBound && !turning)
		{
			shiftDirection = new Vector2(-1, 0);
			transform.position = new Vector2(transform.position.x, transform.position.y - dropDistance);
			shiftSpeed = shiftSpeed * speedUpRatio;

			turning = true;
		}
		else if (transform.position.x <= leftBound && !turning)
		{
			shiftDirection = new Vector2(1, 0);
			transform.position = new Vector2(transform.position.x, transform.position.y - dropDistance);
			shiftSpeed = shiftSpeed * speedUpRatio;

			turning = true;
		}
		else // if we aren't past bounds, we shift
		{
			transform.position += (Vector3)shiftDirection * shiftDistance;
			turning = false;
		}

		// adjust shift period in case shift speed has changed
		shiftPeriod = 1 / shiftSpeed;
	}

	private void Animate()
	{
		EnemyScript enemyScript;

		// nested loops because immediate children are array column objects
		foreach (Transform child in transform)
		{
			foreach (Transform grandchild in child)
			{
				enemyScript = grandchild.GetComponent<EnemyScript>();
				enemyScript.FlipSprite();
			}
		}
	}
	
	private void FireSomewhere()
	{
		// pick a random column
		Transform column = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount));

		// have the lowest alien fire
		Transform firingAlien = column.GetChild(0);
		for (int i = 1; i < column.childCount; i++)
		{
			if (column.GetChild(i).position.y < firingAlien.position.y)
			{
				firingAlien = column.GetChild(i);
			}
		}

		firingAlien.GetComponent<EnemyScript>().Fire();
	}
}
