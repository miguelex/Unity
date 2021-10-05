using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public static int coinsCount = 0;

	// Use this for initialization
	void Start () {
		Coin.coinsCount++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("Player")) {
			Destroy (gameObject);
		}
	}

	void OnDestroy ()
	{
		Coin.coinsCount--;
		if (Coin.coinsCount <= 0)
		{
			GameObject timer = GameObject.Find(("GameTimer"));
			Destroy(timer);

			GameObject[] Fireworks = GameObject.FindGameObjectsWithTag("Firework");
			foreach (GameObject firework in Fireworks)
			{
				firework.GetComponent<ParticleSystem>().Play();
			}
		}
	}
}