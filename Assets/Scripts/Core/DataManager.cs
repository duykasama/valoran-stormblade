using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int health;
    public int coinsCount;
    public int damage;
    public float speed;

    public static DataManager instance;

	void Awake()
	{
		instance = this;
        health = 100;
        coinsCount = 0;
        damage = 10;
        speed = 20;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
