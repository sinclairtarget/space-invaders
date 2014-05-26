using UnityEngine;
using System.Collections;

public class GameOverScreenManager : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Application.LoadLevel ("Menu");
		}
	}
}
