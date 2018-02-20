using UnityEngine;
using System.Collections;

// attach script to main camera
public class CameraController : MonoBehaviour {

	// object to follow (player)
	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}