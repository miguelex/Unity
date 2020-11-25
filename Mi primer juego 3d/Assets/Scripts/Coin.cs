using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public enum CoinType
	{
		BRONZE,
		SILVER,
		GOLD
	};
	
	public CoinType Type;

	public Material[] CoinMaterials;
	
	public static int CoinsCount = 0;

	private int CoinValue = 1;

	private CoinType CoinMaterial
	{
		set
		{
			Type = value;
			int TypeValue = (int) Type;

			Material Mat = CoinMaterials[TypeValue];

			Renderer Rend = GetComponent<Renderer>();

			if (Rend != null)
			{
				Rend.material = Mat;
				CoinValue = 1 + TypeValue * TypeValue;
			}
		}
		get
		{
			return Type;
		}
	}
	
	// Se llama cuando se inicializa el juego
	void Awake ()
	{
		CoinMaterial = Type;
		Coin.CoinsCount += CoinValue;
	}
	
	// Se llama cuando se destruye un objeto
	void OnDestroy()
	{
		if (!UI_Countdown.IsGameFinished)
		{
			UI_Countdown.TimerBonus = 3*CoinValue*CoinValue;
		}
		
		Coin.CoinsCount -= CoinValue;
		UI_Coin.UpdateCoins();
		if (CoinsCount <= 0)
		{
			Debug.Log(("He recogido todas las monedas. Game Over"));
		}
	}

	private void OnTriggerEnter(Collider otherCollider)
	{
		if (otherCollider.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
