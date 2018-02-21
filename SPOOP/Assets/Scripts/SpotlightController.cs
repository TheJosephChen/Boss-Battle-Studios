using UnityEngine;
using System.Collections;

// place spotlight object in scene
// attach script to spotlight object
public class SpotlightController : MonoBehaviour {

	// object to follow (player)
	private GameObject player;

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