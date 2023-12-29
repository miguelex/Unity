using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

	// Destruye el sistema de particulas 
	public float destroyTime = 2.0f;
	// Use this for initialization
	void Start () {
		Invoke("Die", destroyTime);
	}

	void Die()
	{
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
