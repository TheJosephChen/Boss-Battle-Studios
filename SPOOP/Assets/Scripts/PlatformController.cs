using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour 
{
	public float speed;
	public float xDirection;
	public float yDirection;
	public float zDirection;

	public float xRange;
	public float yRange;
	public float zRange;

	private Vector3 initialPosition;
	private Vector3 endPosition;

	void Start ()
	{
		// initialize start and end positions
		initialPosition = transform.position;
		endPosition = new Vector3 (initialPosition.x + xRange, initialPosition.y + yRange, initialPosition.z + zRange);
	}
		
	void Update () 
	{
		Vector3 movement = new Vector3 (xDirection, yDirection, zDirection);
		transform.Translate(movement * Time.deltaTime * speed, Space.World);

		// if at either start or end position, reverse direction
		if (Vector3.Distance(transform.position, initialPosition) <= 0.05 || Vector3.Distance(transform.position, endPosition) <= 0.05) 
		{
			xDirection *= -1;
			yDirection *= -1;
			zDirection *= -1;
		}
	}
}
