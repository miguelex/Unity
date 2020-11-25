using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coin : MonoBehaviour
{

	private static Text CoinText;
	private static int TargetCoins = 0;
	
	// Use this for initialization
	void Start ()
	{
		CoinText = GetComponent<Text>();
		TargetCoins = Coin.CoinsCount;
		UpdateCoins();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void UpdateCoins()
	{
		int RemainsCoins = Coin.CoinsCount;
		int CollectedCoins = TargetCoins - RemainsCoins;
		if (RemainsCoins > 0)
		{
			CoinText.text = "Monedas recogidas\n <color='red'>" + CollectedCoins + " - " + TargetCoins + "</color>";
		}
		else
		{
			CoinText.text = "<color='yellow'>Enhorabuena</color>";
		}
	}
}
