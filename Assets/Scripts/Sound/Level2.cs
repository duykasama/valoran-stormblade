using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
	void Awake()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayLevel2Music();
	}
}
