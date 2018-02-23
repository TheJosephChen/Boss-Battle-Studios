using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float height;
	public float runSpeed;
	public float floorHeight;
	public GameObject obstacle;
	public bool level1Completed;

	private Rigidbody rb;
	private bool isGrounded;
	private Vector3 spawnLocation;
	private Scene activeScene;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		isGrounded = true;
		spawnLocation = new Vector3 (0f, 0.75f, 0f);
		activeScene = SceneManager.GetActiveScene ();
	}

	void Update ()
	{
		if (activeScene.name != "Character Creation") 
		{
			// regular player movement
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			float moveSpeed = speed;
			if (Input.GetKey (KeyCode.LeftShift))
				moveSpeed = moveSpeed * runSpeed;

			float dz = moveVertical * moveSpeed * Time.deltaTime;
			float dx = moveHorizontal * moveSpeed * Time.deltaTime;
			transform.position = new Vector3 (transform.position.x + dx, transform.position.y, transform.position.z + dz);

			// jumping
			if (Input.GetKey (KeyCode.Space) &&
			   isGrounded) {
				rb.AddForce (Vector3.up * height);
				isGrounded = false;
			}

			if (transform.position.y <= -20f) {
				transform.position = spawnLocation;
			}
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "dude lookout")
		{
			transform.parent = other.transform;
			isGrounded = true;
		}

		if (other.gameObject.tag == "dude lookout" && obstacle.activeSelf == false) 
		{
			Debug.Log ("made it");
			obstacle.SetActive (true);
		}

		if (other.gameObject.name == "Checkpoint") 
		{
			spawnLocation = other.transform.position;
			spawnLocation.y += 0.75f;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "dude lookout")
		{
			transform.parent = null;
		}
	}
		
}