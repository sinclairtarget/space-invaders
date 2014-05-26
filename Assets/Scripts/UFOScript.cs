using UnityEngine;
using System.Collections;

public class UFOScript : MonoBehaviour
{
	[HideInInspector]
	public float leftBound;
	[HideInInspector]
	public float rightBound;

	public Sprite explosion;
	public float explosionLength;

	public float soundPeriod;

	private MoveScript moveScript;

	private float soundTime; 

	void Start()
	{
		moveScript = GetComponent<MoveScript>();
		soundTime = soundPeriod;
	}

	// Update is called once per frame
	void Update()
	{
		// if the ufo is going right and is past the right bound
		// or if the ufo is going left and is past the left bound
		// delete it
		if ((transform.position.x > rightBound && moveScript.direction.x > 0) ||
		    (transform.position.x < leftBound && moveScript.direction.x < 0))
		{
			Destroy(this.gameObject);
		}

		soundTime -= Time.deltaTime;

		if (soundTime <= 0)
		{
			SoundEffectsHelper.Instance.PlayUFOSound();

			soundTime = soundPeriod;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// ignore own projectiles
		if (coll.gameObject.name == "Zap(Clone)" || coll.gameObject.name == "Bomb(Clone)")
		{
			return;
		}
		
		Destroy(coll.gameObject);
		
		GetComponent<SpriteRenderer>().sprite = explosion;
		Destroy(this.gameObject, explosionLength);

		GetComponent<MoveScript>().speed = 0;
	}
}
