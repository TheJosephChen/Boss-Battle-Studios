using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyLevel1NextLevel : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag ("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        player.transform.SetParent (null);
        player.transform.position = new Vector3 (0, 3, 0);
        player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        player.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
        DontDestroyOnLoad (player);
        SceneManager.LoadScene ("Level 1");
    }
}
