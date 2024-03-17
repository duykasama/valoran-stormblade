using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
	public AudioSource _audioSource;
	public AudioSource _soundEffectSource;
	public AudioMixer _audioMixer;

	public AudioClip startMenuClip;
	public AudioClip level1Clip;
	public AudioClip level2Clip;
	public AudioClip shopClip;
	public AudioClip victoryClip;

	public AudioClip swordHitClip;
	public AudioClip hurtClip;
	public AudioClip deathClip;

	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	public void PlayStartMenuMusic()
	{
		PlayMusic(startMenuClip);
	}
	
	public void PlayLevel1Music()
	{
		PlayMusic(level1Clip);
	}
	
	public void PlayLevel2Music()
	{
		PlayMusic(level2Clip);
	}

	public void PlayShopMusic()
	{
		PlayMusic(shopClip);
	}
	
	public void PlayVictoryMusic()
	{
		PlayMusic(victoryClip);
	}

	public void PlaySwordHit()
	{
		_soundEffectSource.clip = swordHitClip;
		_soundEffectSource.Play();
	}
	
	public void PlayHurt()
	{
		_soundEffectSource.clip = hurtClip;
		_soundEffectSource.Play();
	}
	
	public void PlayDeath()
	{
		_soundEffectSource.clip = deathClip;
		_soundEffectSource.Play();
	}

	private void PlayMusic(AudioClip clip)
	{
		Debug.Log($"Is music playing??? {_audioSource.isPlaying}");
		if (_audioSource.isPlaying && _audioSource.clip == clip) return;

		//_audioSource.Stop();
		_audioSource.clip = clip;
		_audioSource.Play();
		Debug.Log("Music has been played");
	}

	public void StopMusic()
	{
		_audioSource.Stop();
		Debug.Log("Music has been stopped");
	}
}
