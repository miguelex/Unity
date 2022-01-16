using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDie : MonoBehaviour
{

	private Transform theTransform = null;

	void Awake()
	{
		theTransform = GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (theTransform.position.z > 10 || theTransform.position.z < -10 || theTransform.position.x > 15 || theTransform.position.x < -15)
			Destroy(this.gameObject);
	}
}
