using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().level1Completed = true;
        if (other.transform.CompareTag ("Player"))
            transform.gameObject.SetActive (false);
    }
}
