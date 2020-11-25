using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UI_Radar : MonoBehaviour
{

	public float InsideRadarDistance = 30; //  Metros del mundo real presentes en el minimapa

    public float CoinSizePercentage = 10; // Tamaño de las monedas en relacion al porcentaje del minimapa

    public GameObject CoinImageGold; // prefab del minimapa de monedas doradas
    public GameObject CoinImageSilver; // prefab del minimapa de monedas de plata
    public GameObject CoinImageBroze; // prefab del minimapa de monedas de bronce

    private RawImage RawImageRadarBackground; // minimapa en si, que es una imagen de textura

    private Transform PlayerTransform; // Posicion del jugador

    private float RadarWidth; // Ancho del radar en px
    private float RadarHeight; // Alto del radar en px

    private float CoinWidth; // Ancho de la moneda en px
    private float CoinHeight; // Alto de la moneda en px
    
	// Use this for initialization
	void Start ()
	{
		PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		RawImageRadarBackground = GetComponent<RawImage>();

		RadarWidth = RawImageRadarBackground.rectTransform.rect.width;
		RadarHeight = RawImageRadarBackground.rectTransform.rect.height;

		CoinWidth = RadarWidth * CoinSizePercentage / 100;
		CoinHeight = RadarHeight * CoinSizePercentage / 100;
	}
	
	// Update is called once per frame
	void Update () {
		RemoveAllObjectsFromMinimap();
		FindAndDisplayObjectsForTag("Coin");
	}

	// MUestra los objetos en em minimap con la etiqueta coin
	private void FindAndDisplayObjectsForTag(string tag)
	{
		Vector3 PlayerPosition = PlayerTransform.position;
		GameObject[] AllTheCoins = GameObject.FindGameObjectsWithTag("Coin");

		foreach (GameObject CoinGO in AllTheCoins)
		{
			Vector3 CoinPosition = CoinGO.transform.position;
			float DistanceToCoin = Vector3.Distance(CoinPosition, PlayerPosition);

			if (DistanceToCoin <= InsideRadarDistance)
			{
				Vector3 NormalizeCoinPOsition = NormalizedPosition(PlayerPosition, CoinPosition);
				Vector2 CoinMinimapPosition = CalculateObjectPositition(NormalizeCoinPOsition);
				Coin c = CoinGO.GetComponent<Coin>();
				GameObject prefab = null; 
				if (c.Type == Coin.CoinType.BRONZE)
				{
					prefab = CoinImageBroze;
				} else if (c.Type == Coin.CoinType.SILVER)
				{
					prefab = CoinImageSilver;
				}
				else
				{
					prefab = CoinImageGold;
				}
				
				DrawObjectInMinimap(CoinMinimapPosition, prefab);
			}
		}
	}

	// Elimina todos los objetos del minimpa
	private void RemoveAllObjectsFromMinimap()
	{
		GameObject[] AllTheCoins = GameObject.FindGameObjectsWithTag("Minimap");
		foreach (GameObject CoinGO in AllTheCoins)
		{
			Destroy(CoinGO);
		}
	}
	
	//Nos devuleve el vector que sale de la posicion del jugador y apunta donde esta la moneda normalizada al tamaño del mapa
	private Vector3 NormalizedPosition(Vector3 PlayerPos, Vector3 TargetPos)
	{
		float NormaliseXPosition = (TargetPos.x - PlayerPos.x) / InsideRadarDistance;
		float NormaliseZPosition = (TargetPos.z - PlayerPos.z) / InsideRadarDistance;
		
		
		return new Vector3(NormaliseXPosition, 0,NormaliseZPosition);
	}
	
	// Dado un objeto en el munod 3d, que coordenadas le tocan
	private Vector2 CalculateObjectPositition(Vector3 TargetPos)
	{
		// Angulo que formar el vector del jugador y de la moneda
		float AngleTarget = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
		float AnglePlayer = PlayerTransform.eulerAngles.y;
		float AngleRadarDegress = AngleTarget - AnglePlayer - 90;
		float AngleRadarRadian = AngleRadarDegress * Mathf.Deg2Rad;
		// Calcular las coordenas x e y en el minimapa
		float NormaliseDistanceFromPlayerToTarget = TargetPos.magnitude;
		

		float MinimapX = NormaliseDistanceFromPlayerToTarget * Mathf.Cos(AngleRadarRadian);
		float MinimapY = NormaliseDistanceFromPlayerToTarget * Mathf.Sin(AngleRadarRadian);

		MinimapX *= RadarWidth / 2;
		MinimapY *= RadarHeight / 2;

		MinimapX += RadarWidth / 2;
		MinimapY += RadarHeight / 2;
		
		return new Vector2(MinimapX, MinimapY);
	}
	
	// Pinta el prefab en la posicion indicada
	private void DrawObjectInMinimap(Vector2 Pos, GameObject ObjectPrefab)
	{
		GameObject MinimapGO = (GameObject) Instantiate(ObjectPrefab);
		
		MinimapGO.transform.SetParent(transform.parent);
		
		RectTransform Rt = MinimapGO.GetComponent<RectTransform>();
		Rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,Pos.x, CoinWidth);
		Rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,Pos.y,CoinHeight);

	}
	
}
