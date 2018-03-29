using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitController : MonoBehaviour
{
    public GameObject platform;
    public Material red;
    public Material green;

    private bool hit;

    void Start ()
    {
        hit = false;
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag ("Bullet")) 
        {
            bool isActive = platform.gameObject.activeSelf;
            platform.gameObject.SetActive (!isActive);
            foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
            {
                if (!hit)
                    rend.material = green;
                else
                    rend.material = red;
            }
            hit = !hit;
        }   
    }
}