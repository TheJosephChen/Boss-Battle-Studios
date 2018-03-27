using UnityEngine;
using System.Collections;

// attach script to light over Level 2 door
public class LobbyLevel2LightSwitch : MonoBehaviour {

    private GameObject player;

    private Vector3 offset;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void LateUpdate ()
    {
        if (!player.GetComponent<PlayerController> ().level1Completed || player.GetComponent<PlayerController> ().level2Completed)
            gameObject.SetActive (false);
    }
}
