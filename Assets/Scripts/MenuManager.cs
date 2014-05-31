using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	static int i = 1;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Application.LoadLevel("Invaders");
			i++;
		}
	}
}
