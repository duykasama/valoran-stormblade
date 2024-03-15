using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSound : MonoBehaviour
{
	void Awake()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayShopMusic();
	}
}
