using UnityEngine;
using System.Collections;

// attach script to main camera
public class CameraController : MonoBehaviour {

    // object to follow (player)
    private GameObject player;
    private Vector3 offset;

    void Start ()
    {
        player = GameObject.FindWithTag ("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
		if (Input.GetKey (KeyCode.E) && player.GetComponent<PlayerController> ().level2Completed) 
		{
			transform.RotateAround (player.transform.position, new Vector3 (1, 0, 0), -30);		
		}
    }
}