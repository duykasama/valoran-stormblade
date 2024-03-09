using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Restart() {
        Debug.Log("game over");
        DataManager.instance.health = 100;
        DataManager.instance.speed = 20;
        DataManager.instance.damage = 10;
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
