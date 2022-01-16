using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotation : MonoBehaviour {

    private Transform theTransform = null;

    public float speedRotation = 5.0f;

    void Awake()
    {
	    theTransform = GetComponent<Transform>();
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		theTransform.Rotate(0.0f, 0.0f, 1.0f*speedRotation);
	}
}
