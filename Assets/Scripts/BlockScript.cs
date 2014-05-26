using UnityEngine;
using System.Collections;

// script that governs how a block (or corner) decays under fire
public class BlockScript : MonoBehaviour
{
	public Sprite health3; 
	public Sprite health2; // health 2
	public Sprite health1; // health 1

	private SpriteRenderer spriteRenderer;
	private int health;

	// Use this for initialization
	void Start() 
	{
		health = 4; // full health
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		// destroy the shot
		Destroy(coll.gameObject);

		health--;

		switch (health)
		{
			case 3:
				spriteRenderer.sprite = health3;
				break;

			case 2:
				spriteRenderer.sprite = health2;
				break;

			case 1:
				spriteRenderer.sprite = health1;
				break;

			case 0:
				Destroy(this.gameObject);
				break;

			default:
				Debug.LogError("Block health is unexpected value");
				break;
		}
	}
}
