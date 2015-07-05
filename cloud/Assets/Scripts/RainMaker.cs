using UnityEngine;
using System.Collections;

public class RainMaker : MonoBehaviour
{

	public GameObject rainSource;
	public GameObject rainDrop;
	public float rainRate = 0.1f;
	public float initialVelocity = 0.0f;

	private float rainSourceWidth;
	
	// Use this for initialization
	void Start ()
	{
		rainSourceWidth = rainSource.GetComponent<BoxCollider2D> ().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Jump") || Input.GetKeyDown ("space")) {
			InvokeRepeating ("MakeRain", 0.0f, rainRate);
		}
		if (Input.GetButtonUp ("Jump")) {
			CancelInvoke ("MakeRain");
		}
	}
	
	void MakeRain ()
	{
		Vector3 spawnPosition = new Vector3 (
				rainSource.transform.position.x + Random.Range (-rainSourceWidth, rainSourceWidth),
				rainSource.transform.position.y,
				0.0f
		);
		GameObject clone = (GameObject)Instantiate (rainDrop, spawnPosition, Quaternion.identity);
		Rigidbody2D rb2d = clone.GetComponent<Rigidbody2D> ();
		rb2d.AddForce (new Vector2 (0.0f, -initialVelocity));
	}
}
