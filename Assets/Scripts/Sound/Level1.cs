using UnityEngine;

public class Level1 : MonoBehaviour
{
	void Awake()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayLevel1Music();
	}
}
