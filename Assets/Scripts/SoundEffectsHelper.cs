using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour
{
	// singleton
	public static SoundEffectsHelper Instance;

	// sounds
	public AudioClip tankFire;
	public AudioClip playerDeath;
	public AudioClip alienDeath;
	public AudioClip UFOSound;
	public AudioClip march1;
	public AudioClip march2;
	public AudioClip march3;
	public AudioClip march4;
	
	public void Awake() 
	{
		// register singleton
		if (Instance != null)
		{
			Debug.LogError("More than one sound effects helper being created!");
		}

		Instance = this;
	}
	
	public void PlayTankFireSound()
	{
		MakeSound(tankFire);
	}

	public void PlayPlayerDeathSound()
	{
		MakeSound(playerDeath);
	}

	public void PlayAlienDeathSound()
	{
		MakeSound(alienDeath);
	}

	public void PlayUFOSound()
	{
		MakeSound(UFOSound);
	}

	public void PlayMarchSound(int step)
	{
		switch (step)
		{
		case 1:
			MakeSound(march1);
			break;

		case 2:
			MakeSound (march2);
			break;

		case 3:
			MakeSound (march3);
			break;

		case 4:
			MakeSound(march4);
			break;

		default:
			Debug.LogError("Unexpected play march sound parameter!");
			break;
		}
	}

	private void MakeSound(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, transform.position); // position doesn't matter as sounds aren't 3D
	}
}
