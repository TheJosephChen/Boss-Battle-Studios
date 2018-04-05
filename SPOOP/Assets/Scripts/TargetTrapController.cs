using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrapController : MonoBehaviour
{
    public GameObject platform;
    public GameObject switchTarget;
    public Material red;
    public Material green;

    private bool hit;

    void Start ()
    {
        hit = false;
    }

    void OnCollisionEnter (Collision other)
    {
        // only trigger trap once
        if (other.transform.CompareTag ("Bullet") && !hit) 
        {
            bool isActive = platform.gameObject.activeSelf;
            platform.gameObject.SetActive (!isActive);
            foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
            {
                rend.material = green;
            }
            // reset attached target
            foreach (Renderer rend in switchTarget.GetComponentsInChildren<Renderer>()) 
            {
                rend.material = red;
            }

            hit = !hit;
        }   
    }
}