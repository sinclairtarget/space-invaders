using UnityEngine;
using System.Collections;

// enemy needs to...
// die on impact with shot, delete shot, animate, fire

public class EnemyScript : MonoBehaviour
{
	// two sprites, legs open and legs closed
	public Sprite open;
	public Sprite closed;
	public Sprite explosion;
	public float explosionLength; // in seconds, time explosion sprite should be displayed

	private SpriteRenderer spriteRenderer;
	private WeaponScript weaponScript;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		weaponScript = GetComponentInChildren<WeaponScript>();
		
		// should probably be set in inspector, but there are too many objects for that now
		weaponScript.muzzleVelocity = 3;
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		// ignore own projectiles
		if (coll.gameObject.name == "Zap(Clone)" || coll.gameObject.name == "Bomb(Clone)")
		{
			return;
		}
		
		Destroy(coll.gameObject);
		
		spriteRenderer.sprite = explosion;
		Destroy(this.gameObject, explosionLength);
	}

	public void FlipSprite()
	{
		if (spriteRenderer.sprite == open)
		{
			spriteRenderer.sprite = closed;
		}
		else if (spriteRenderer.sprite == closed)
		{
			spriteRenderer.sprite = open;
		}
	}

	public void Fire()
	{
		weaponScript.Fire(new Vector2(0, -1)); // fire downwards
	}
}
