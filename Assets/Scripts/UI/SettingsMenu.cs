using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

	void Awake()
	{
        audioMixer.GetFloat("volume", out var vol);
        Debug.Log($"The volume is {vol}");
        gameObject.GetComponentInChildren<Slider>().value = (vol + 40)/40;
	}

	public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SetVolume(float volume)
    {
		audioMixer.SetFloat("volume", volume * 40 - 40);
    }
}
