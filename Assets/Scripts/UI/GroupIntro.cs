using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroupIntro : MonoBehaviour
{
    public void Continue()
    {
        Debug.Log("Load start menu");
        SceneManager.LoadScene("StartMenu");
    }

}
