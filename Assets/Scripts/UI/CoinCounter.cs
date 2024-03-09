using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    private TMP_Text coinText;
    public int currentCoins = 0;

	void Awake()
	{
		instance = this;
        coinText = GetComponentInChildren<TMP_Text>();
        Debug.Log("Awake called");
	}

	void Start()
    {
        coinText.text = "Coins: " + currentCoins;
        Debug.Log("Start called");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = "Coins: " + currentCoins;
        DataManager.instance.coinsCount = currentCoins;
    }
}
