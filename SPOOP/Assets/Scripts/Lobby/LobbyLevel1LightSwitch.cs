using UnityEngine;
using System.Collections;

// attach script to light over Level 1 door
public class LobbyLevel1LightSwitch : MonoBehaviour {

	private GameObject player;

	private Vector3 offset;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate ()
	{
		if (player.GetComponent<PlayerController> ().level1Completed)
			gameObject.SetActive (false);
	}
}