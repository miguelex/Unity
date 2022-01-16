using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsOnDestruction : MonoBehaviour {

	public int scorePoints = 200;

	private void OnDestroy()
	{
		GameController.score += scorePoints;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
