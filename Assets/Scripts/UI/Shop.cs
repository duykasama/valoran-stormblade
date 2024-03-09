using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    private int coinsCount = 0;
    private TMP_Text coinsText;

	private void Awake()
	{
		coinsText = GetComponentInChildren<TMP_Text>();
        coinsCount = DataManager.instance.coinsCount;
	}

	private void Start()
	{
        coinsText.text = $": {coinsCount}";
	}

	public void BuyHealthPotion()
    {
        if (coinsCount >= 2)
            coinsCount -= 2;
        UpdateCoinsCount();
        DataManager.instance.health += 50;
        DataManager.instance.health = Math.Min(DataManager.instance.health, 100);
    }
    
    public void BuyDamagePotion()
    {
        if (coinsCount >= 5)
            coinsCount -= 5;
        UpdateCoinsCount();
        DataManager.instance.damage += 10;
    }
    
    public void BuySpeedPotion()
    {
        if (coinsCount >= 2)
            coinsCount -= 2;
        UpdateCoinsCount();
        DataManager.instance.speed += 5;
    }

    private void UpdateCoinsCount()
    {
		coinsText.text = $": {coinsCount}";
        DataManager.instance.coinsCount = coinsCount;
	}

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2");
    }
}
