using UnityEngine;
using System.Collections;

// attach script to light over Level 3 door
public class LobbyLevel3LightSwitch : MonoBehaviour {

    private GameObject player;

    private Vector3 offset;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void LateUpdate ()
    {
        if (!player.GetComponent<PlayerController> ().level1Completed || !player.GetComponent<PlayerController> ().level2Completed || player.GetComponent<PlayerController> ().level3Completed)
            gameObject.SetActive (false);
    }
}
