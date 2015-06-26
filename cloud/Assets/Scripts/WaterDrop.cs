using UnityEngine;
using System.Collections;

public class WaterDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("WaterReceiver")) {
			coll.gameObject.GetComponent<IWaterReceiver>().ReceiveWater();
			print("giving water!");
		}
		Destroy(this.gameObject);
	}
}
