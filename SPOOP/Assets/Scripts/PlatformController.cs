using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour 
{
    public float speed;
    public float xDirection;
    public float yDirection;
    public float zDirection;

    public float xRange;
    public float yRange;
    public float zRange;

    private Vector3 initialPosition;
    private Vector3 endPosition;
    private float waitUntilTime = -1f;
    private Vector3 movement;

    void Start ()
    {
        // initialize start and end positions
        initialPosition = transform.position;
        endPosition = new Vector3 (initialPosition.x + xRange, initialPosition.y + yRange, initialPosition.z + zRange);
    }
        
    void FixedUpdate () 
    {
        if (Time.time < waitUntilTime) {
            movement = new Vector3 (0f, 0f, 0f);
        } else {    
            movement = new Vector3 (xDirection, yDirection, zDirection);
        }

        if (waitUntilTime == -1f) {
            transform.Translate (movement * Time.deltaTime * speed, Space.World);
        }

        // if at either start or end position, reverse direction
        if (Vector3.Distance (transform.position, initialPosition) <= 0.045 || Vector3.Distance (transform.position, endPosition) <= 0.045) 
        {
            if (waitUntilTime == -1f) 
            {
                waitUntilTime = Time.time + 0.75f;
            } 
            else if (Time.time >= waitUntilTime)
            {
                xDirection *= -1;
                yDirection *= -1;
                zDirection *= -1;
                waitUntilTime = -1f;
            }
        }
    }
}
