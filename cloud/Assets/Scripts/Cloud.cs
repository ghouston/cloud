using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	
	public GameObject pissHole;
	public GameObject piss;
	public float pissRate = 0.1f;
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetKeyDown("space")){
			InvokeRepeating("Piss", 0.0f, pissRate);
		}
		if (Input.GetButtonUp("Jump")) {
			CancelInvoke("Piss");
		}
	}
	
	void Piss () {
		Instantiate(piss, pissHole.transform.position, Quaternion.identity);
	}
}
