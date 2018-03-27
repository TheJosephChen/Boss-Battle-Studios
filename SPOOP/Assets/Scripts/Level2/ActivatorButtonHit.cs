using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorButtonHit : MonoBehaviour
{
    public GameObject platform;

    private bool hit;
    private Color currentColor;
    private Color pink = new Color(255, 0, 237, 255);
    private Color green = new Color(0, 255, 0, 255);

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
            if (!hit)
                gameObject.GetComponent<Renderer> ().material.color = green;
            else
                gameObject.GetComponent<Renderer> ().material.color = pink;
            hit = !hit;
        }   
    }
}
