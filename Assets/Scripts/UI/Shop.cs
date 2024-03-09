using System;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int coinsCount = 10;
    private TMP_Text coinsText;

	private void Awake()
	{
		coinsText = GetComponentInChildren<TMP_Text>();
	}

	private void Start()
	{
        coinsText.text = $": {coinsCount}";
	}

	public void BuyHealthPotion()
    {
        if (coinsCount >= 2)
            coinsCount -= 2;
        coinsText.text = $": {coinsCount}";
    }
    
    public void BuyDamagePotion()
    {
        if (coinsCount >= 5)
            coinsCount -= 5;
        coinsText.text = $": {coinsCount}";
    }
    
    public void BuySpeedPotion()
    {
        if (coinsCount >= 2)
            coinsCount -= 2;
        coinsText.text = $": {coinsCount}";
    }
}
