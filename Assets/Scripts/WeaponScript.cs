using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
	public GameObject shotType;
	public float firingRate; // shots per second
	public float muzzleVelocity; // game units per second
	public float range; // game units

	private float cooldown;
	
	// Use this for initialization
	public void Start() 
	{
		cooldown = 0;
	}

	public void Update()
	{
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
	}

	public void Fire(Vector2 direction)
	{
		if (cooldown <= 0)
		{
			GameObject shot = (GameObject) Instantiate(shotType);

			// create shot at muzzle of gun
			shot.transform.position = transform.position;

			// set shot direction and speed
			MoveScript moveScript = shot.GetComponent<MoveScript>();

			if (moveScript == null)
			{
				Debug.LogError("moveScript is null");
			}

			moveScript.direction = direction;
			moveScript.speed = muzzleVelocity;

			// set shot range
			float shotLifetime = range / muzzleVelocity;
			Destroy(shot, shotLifetime); // destroy shot when it reaches its range

			// reset cooldown
			cooldown = firingRate;

			// play shot sound if tank shot
			if (transform.parent.tag == "Player")
			{
				SoundEffectsHelper.Instance.PlayTankFireSound();
			}
		}
	}
}
