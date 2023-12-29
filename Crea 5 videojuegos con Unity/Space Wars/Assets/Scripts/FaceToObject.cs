using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToObject : MonoBehaviour
{

	public Transform objectToFollow = null;

	public bool followObject = false;

	private Transform theTransform = null;

	void Awake()
	{
		theTransform = GetComponent<Transform>();

		if (!followObject)
		{
			return;
		}

		GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");

		if (thePlayer != null)
		{
			objectToFollow = thePlayer.GetComponent<Transform>();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (objectToFollow == null)
		{
			return;
		}

		Vector3 directionToFollow = objectToFollow.position - theTransform.position;
		if (directionToFollow != Vector3.zero)
		{
			theTransform.localRotation = Quaternion.LookRotation(directionToFollow.normalized, Vector3.up);
		}
	}
}
