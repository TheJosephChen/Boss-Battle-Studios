using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float height;
	public float runSpeed;

	private Rigidbody rb;
	private bool isGrounded;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		isGrounded = true;
	}

	void Update ()
	{
		// regular player movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float moveSpeed = speed;
		if (Input.GetKey (KeyCode.LeftShift))
			moveSpeed = moveSpeed * runSpeed;

		float dz = moveVertical * moveSpeed * Time.deltaTime;
		float dx = moveHorizontal * moveSpeed * Time.deltaTime;
		transform.position = new Vector3(transform.position.x + dx, transform.position.y, transform.position.z + dz);

		// jumping
		if (Input.GetKey(KeyCode.Space) && 
			isGrounded)
		{
			rb.AddForce (Vector3.up * height);
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}
}