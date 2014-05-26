using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// singleton
	public static GameManager Instance;

	public GameObject UFOType;
	public float UFOFrequency; // ufos per minute
	public float UFOSpeed; // game units per sec
	public Vector2 UFOLeftStart;
	public Vector2 UFORightStart;

	private float UFOPeriod;
	private float UFOTimer;

	private int score;
	private int lives;

	void Awake()
	{
		// register the singleton
		if (Instance != null)
		{
			Debug.LogError("Muliple instance of GameManager");
		}

		Instance = this;
	}

	// Use this for initialization
	void Start() 
	{
		UFOPeriod = (1 / UFOFrequency) * 60; // seconds between UFOs

		// some number around UFOPeriod
		UFOTimer = UFOPeriod + UnityEngine.Random.Range(-UFOPeriod * 0.2f, UFOPeriod * 0.2f); 

		score = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		UFOTimer -= Time.deltaTime;
	
		if (UFOTimer <= 0)
		{
			// create UFO at either the left or right side of the screen
			GameObject UFO = (GameObject)Instantiate(UFOType);
			MoveScript moveScript = UFO.GetComponent<MoveScript>();

			float side = UnityEngine.Random.Range(1.0f, 2.0f);

			if (side < 1.5)
			{
				UFO.transform.position = UFOLeftStart;
				moveScript.direction = new Vector2(1, 0);
			}
			else
			{
				UFO.transform.position = UFORightStart;
				moveScript.direction = new Vector2(-1, 0);
			}

			moveScript.speed = UFOSpeed;

			// set bounds
			UFOScript ufoScript = UFO.GetComponent<UFOScript>();
			ufoScript.leftBound = UFOLeftStart.x;
			ufoScript.rightBound = UFORightStart.x;

			// some number around UFOPeriod
			UFOTimer = UFOPeriod + UnityEngine.Random.Range(-UFOPeriod * 0.2f, UFOPeriod * 0.2f);
		}
	}

	public void AddToScore(int amount)
	{
		score += amount;
		GUIScript.Instance.UpdateScore(score);
	}

	public void AdjustLives(int newLives)
	{
		lives = newLives;

		GUIScript.Instance.UpdateLives(lives);
	}
}
