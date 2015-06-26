using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour, IWaterReceiver {

	public float healthyWaterLevel = 10.0f;
	public float lowWaterLevel = 5.0f;
	public float shriveledWaterLevel = 2.0f;
	public float drowningWaterLevel = 15.0f;
	public float waterLevel = 5.0f;
	public float waterLossRate = 0.2f;
	
	public Color plantColor = Color.green;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		waterLevel -= waterLossRate * Time.deltaTime;
		UpdateColor();
		if(waterLevel <= 0 || waterLevel >= drowningWaterLevel) {
			Destroy(this.gameObject);
		}
	}
	
	void UpdateColor () {
		plantColor = Color.Lerp(new Color(0.1f, 0.4f, 0.4f), Color.green, waterLevel/healthyWaterLevel);
		this.GetComponent<SpriteRenderer>().color = plantColor;
	}
	
	public void ReceiveWater () {
		waterLevel += 1;
	}
	
	public void LoseWater () {
		//no use yet
	}
}
