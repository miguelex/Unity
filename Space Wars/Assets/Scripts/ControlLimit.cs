using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimit : MonoBehaviour
{

	private Transform theTransform = null;
	public Vector2 horizontalRange = Vector2.zero;// Limite izquierod, limite derecho
	public Vector2 verticalRange = Vector2.zero;// limite superriot, limite inferior

	void Awake()
	{
		theTransform = GetComponent<Transform>();
	}

	void LateUpdate()
	{
		theTransform.position = new Vector3(
			Mathf.Clamp(theTransform.position.x, horizontalRange.x, horizontalRange.y),
			theTransform.position.y,
			Mathf.Clamp(theTransform.position.z,verticalRange.x, verticalRange.y)
			);
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
