using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float maxTime = 90.0f;
	private float countdown = 0.0f;
	
	// Use this for initialization
	void Start () {
		countdown = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0) {
			Coin.coinsCount = 0;
			SceneManager.LoadScene ("MainScene");
		}
	}
}
