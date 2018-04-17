using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SwitchPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().level2Completed = true;
        if (other.transform.CompareTag ("Player"))
        {
            transform.gameObject.SetActive (false);
            EditorUtility.DisplayDialog ("You got a gravity switch!", "Press E to activate!", "Okay");
        }
    }
}
