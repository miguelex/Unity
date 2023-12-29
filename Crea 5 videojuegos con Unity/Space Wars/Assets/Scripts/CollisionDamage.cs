using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{

	public float damagePoints = 10.0f;

	private void OnTriggerStay(Collider otherCollider)
	{
		Health health = otherCollider.GetComponent<Health>();

		if (health == null)
		{
			return;
		}

		health.healthPoints -= damagePoints * Time.deltaTime;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
