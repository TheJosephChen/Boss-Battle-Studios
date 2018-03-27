using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyLevel1NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController> ().level1Completed) 
        {
            other.transform.SetParent (null);
            other.transform.position = new Vector3 (0, 3, 0);
            other.GetComponent<Rigidbody> ().velocity = Vector3.zero;
            other.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
            DontDestroyOnLoad (other.gameObject);
            SceneManager.LoadScene ("Level 1");
        } 
        else 
        {
            gameObject.GetComponent<BoxCollider> ().isTrigger = false;
        }
    }
}
