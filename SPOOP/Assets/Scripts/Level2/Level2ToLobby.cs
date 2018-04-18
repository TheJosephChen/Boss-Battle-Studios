using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2ToLobby : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            other.transform.SetParent (null);
            other.transform.position = new Vector3 (-1, 5, -42);
            other.GetComponent<Rigidbody> ().velocity = Vector3.zero;
            other.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
            other.GetComponent<PlayerController> ().isGrounded = false;
            other.GetComponent<PlayerController>().SwitchGravity();
            DontDestroyOnLoad (other.gameObject);
            SceneManager.LoadScene ("Lobby");
            GameObject.FindGameObjectWithTag ("Door 2").GetComponent<BoxCollider> ().isTrigger = false;
        }
    }
}
