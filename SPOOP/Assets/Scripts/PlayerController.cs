using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float height;
	public float runSpeed;

	private Rigidbody rb;
	private float runMove;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		runMove = speed * runSpeed;
	}

	void FixedUpdate ()
	{
		// regular player movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// check if running
		if (Input.GetKey (KeyCode.LeftShift)) {
			rb.AddForce (movement * runMove);
		} else {
			// not running
			rb.AddForce (movement * speed);
		}

		// jumping
		//TODO: check if player is already jumping
		if (Input.GetKeyDown (KeyCode.Space) && transform.position.y == 0.5) {
			rb.AddForce (Vector3.up * height);
		}
	}
}