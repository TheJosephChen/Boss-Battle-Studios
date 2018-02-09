using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to be applied to the object that moves
public class Moving : MonoBehaviour
{
	public int moveSpeed;

	private Vector3 moveDirection;
	private Vector3 endPosition;
	private bool moving;

	void Start()
	{
		moving = false;
	}

	void Update()
	{
		//move
		if (moving)
			transform.Translate (moveDirection * moveSpeed * Time.deltaTime);

		//move until close enough to end position
		if (Vector3.Distance (transform.position, endPosition) < 0.1)
			moving = false;
	}

	void OnCollisionEnter(Collision coll)
	{
		if (!moving) //make sure we don't change direction while already moving
		{
			var normal = coll.contacts [0].normal;
			if (normal != Vector3.up && //don't move on collisions with floor
				//only move in diagonals
			   (normal == Vector3.forward || normal == Vector3.right || normal == Vector3.left || normal == Vector3.back))
			{
				moving = true;
				moveDirection = normal;
				endPosition = transform.position + moveDirection;
			}
		}
	}
}
