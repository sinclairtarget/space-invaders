using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Application.LoadLevel("Invaders");
		}
	}
}
