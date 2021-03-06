﻿using UnityEngine;
using System.Collections;

// attach script to main camera
public class CameraController : MonoBehaviour
{
    public bool gravity;
    private GameObject player;
    private Vector3 offset;
    private Quaternion normalGravity, reverseGravity;
    private float yOffset;

    public float switchRate = 1f;
    private float timeToSwitch = 0f;

    void Start ()
    {
        player = GameObject.FindWithTag ("Player");
        offset = transform.position - player.transform.position;
        gravity = true;
        yOffset = offset.y;

        //get necessary rotations
        normalGravity = transform.rotation;
        transform.Rotate (-30, 0, 0);
        reverseGravity = transform.rotation;
        transform.Rotate (30, 0, 0);
    }

    void Update()
    {
        //if reversed gravity, rotate and move camera until in position
        if (!gravity)
        {
            if (transform.rotation != reverseGravity)
                transform.Rotate (-Time.deltaTime * 15, 0, 0);
            if (offset.y > -yOffset)
                offset.y = offset.y - Time.deltaTime * 5;
        }
        //if regular gravity, rotate and move camera until in position
        else
        {
            if (transform.rotation != normalGravity)
                transform.Rotate (Time.deltaTime * 15, 0, 0);
            if (offset.y < yOffset)
                offset.y = offset.y + Time.deltaTime * 5;
        }

        //reverse gravity
        if (Input.GetKeyDown (KeyCode.E)
            && player.GetComponent<PlayerController> ().level2Completed
            && Time.time >= timeToSwitch)
        {
            timeToSwitch = Time.time + 1f / switchRate;
            gravity = !gravity;
        }
    }

    void LateUpdate ()
    {
        //follow around player
        transform.position = player.transform.position + offset;
    }
}