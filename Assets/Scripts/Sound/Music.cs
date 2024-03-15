using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
	public AudioSource _audioSource;
	public AudioMixer _audioMixer;

	public AudioClip startMenuClip;
	public AudioClip level1Clip;
	public AudioClip level2Clip;
	public AudioClip victoryClip;

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
	
	public void PlayVictoryMusic()
	{
		PlayMusic(victoryClip);
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
