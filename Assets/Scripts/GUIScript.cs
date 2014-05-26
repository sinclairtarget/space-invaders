using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{
	// singleton
	public static GUIScript Instance;

	public GameObject GUITankType;
	public Vector2 firstTankPos;
	public float tanksSpacing;

	private GUIText scoreText;
	private GameObject[] GUITanks;
	
	void Awake() 
	{
		if (Instance != null)
		{
			Debug.LogError("More than one instance of GUIScript being created!");
		}

		Instance = this;
	}

	void Start()
	{
		scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<GUIText>();
		GUITanks = new GameObject[3]; // max lives is 3
	}
	
	public void UpdateScore(int score)
	{
		scoreText.text = score.ToString();
	}

	public void UpdateLives(int lives)
	{
		for (int i = 0; i < GUITanks.Length; i++)
		{
			if (i < lives)
			{
				if (GUITanks[i] != null)
				{
					continue;
				}

				GUITanks[i] = (GameObject)Instantiate(GUITankType);
				
				GUITanks[i].transform.position = new Vector2(firstTankPos.x + (i * tanksSpacing), firstTankPos.y);
			}
			else
			{
				Destroy(GUITanks[i]);
			}
		}
	}
}
