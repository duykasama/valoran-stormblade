using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume * 100 - 80);
        audioMixer.GetFloat("volume", out var masterVolume);
    }
}
