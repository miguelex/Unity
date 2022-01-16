using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public GameObject deathParticlesPrefab = null;

	private Transform theTransform = null;

	public bool shouldBeDestroyedOnDeath = true;
	public bool shouldShowGameOVerOnDeath = false;

	public float healthPoints
	{
		get
		{
			return _healthPoints;
		}

		set
		{
			_healthPoints = value;

			if (_healthPoints <= 0)
			{
				SendMessage("Die", SendMessageOptions.DontRequireReceiver);

				if (deathParticlesPrefab != null)
				{
					Instantiate(deathParticlesPrefab, theTransform.position, theTransform.rotation);
					if (shouldBeDestroyedOnDeath)
					{
						Destroy(gameObject);
					}

					if (shouldShowGameOVerOnDeath)
					{
						GameController.GameOver();
					}
				}
			}
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		theTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[SerializeField] 
	private float _healthPoints = 100.0f;
}
