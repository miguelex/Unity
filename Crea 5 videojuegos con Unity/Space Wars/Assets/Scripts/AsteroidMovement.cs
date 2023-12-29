using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour {

	private Transform theTransform = null;
	public float maxSpeed = 1.0f;
	private int direction;
	void Awake()
	{
		theTransform = GetComponent<Transform>();
		direction = Random.Range(0, 4);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (direction)
		{
			case 0: theTransform.position += theTransform.forward * maxSpeed * Time.deltaTime;
					break;
			case 1: theTransform.position += -1 * theTransform.forward * maxSpeed * Time.deltaTime;
					break;
			case 2: theTransform.position += theTransform.right * maxSpeed * Time.deltaTime;
					break;
			case 3: theTransform.position += -1 * theTransform.right * maxSpeed * Time.deltaTime;
				break;
		}
		
	}
}
