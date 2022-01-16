using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour {

	public float maxRadius = 7.0f;

	public float interval = 10.0f;

	public GameObject objectToSpawn = null;

	private Transform origin = null;
	
	void Awake()
	{
		origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 5.0f, interval);
	}
	
	void Spawn()
	{
		if (origin == null)
			return;

		Vector3 spawnPosition = origin.position + Random.onUnitSphere * maxRadius;
		spawnPosition = new Vector3(spawnPosition.x, 0.0f, spawnPosition.z);
		Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
