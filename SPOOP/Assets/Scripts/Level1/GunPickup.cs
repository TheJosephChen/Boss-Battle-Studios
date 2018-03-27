using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GunPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().level1Completed = true;
        if (other.transform.CompareTag ("Player"))
        {
            transform.gameObject.SetActive (false);
            EditorUtility.DisplayDialog ("You got a gun!", "Press enter to fire!", "Okay");
        }
    }
}
