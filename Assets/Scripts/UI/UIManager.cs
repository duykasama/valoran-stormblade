using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;
    //[SerializeField] private AudioClip gameOverSound;
    public void GameOver() { 
        gameOverScene.SetActive(true); 
        //SoundManager.instance.PlaySound(gameOverSound);
     }
}
