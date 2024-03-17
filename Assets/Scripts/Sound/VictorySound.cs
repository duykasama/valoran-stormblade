using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
	void Awake()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayVictoryMusic();
	}
}
