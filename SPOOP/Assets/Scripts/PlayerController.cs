using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float speed;
	public float height;
	public float runSpeed;
	public float floorHeight;

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

		// check if running, else normal speed
		rb.AddForce (Input.GetKey (KeyCode.LeftShift) ? movement * runMove : movement * speed);

		// jumping
		//TODO: handle changing floor Heights
		if (Input.GetKeyDown (KeyCode.Space) && transform.position.y == floorHeight) 
		{
			rb.AddForce (Vector3.up * height);
		}

	}
}