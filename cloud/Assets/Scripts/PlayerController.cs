using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public bool
		facingRight = true;
	[HideInInspector]
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	//public Transform groundCheck;
	
	
	//private bool grounded = false;
	//private Animator anim;
	private Rigidbody2D rb2d;
	
	
	// Use this for initialization
	void Awake ()
	{
		//anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));


	}
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		//anim.SetFloat ("Speed", Mathf.Abs (h));
		
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce (Vector2.right * h * moveForce);

		if (v * rb2d.velocity.y < maxSpeed)
			rb2d.AddForce (Vector2.up * v * moveForce);
		
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (Mathf.Abs (rb2d.velocity.y) > maxSpeed)
			rb2d.velocity = new Vector2 (rb2d.velocity.x, Mathf.Sign (rb2d.velocity.y) * maxSpeed);
		
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

	}
	
	
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}