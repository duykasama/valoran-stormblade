using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
