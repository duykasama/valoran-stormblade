using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	void Awake()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayStartMenuMusic();
	}
	public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    
    public void OpenHowtoPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
