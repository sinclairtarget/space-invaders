using UnityEngine;
using System.Collections;

// handle shot collisions
public class ShotScript : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "shot")
		{
			Destroy(coll.gameObject);
		}
	}
}
