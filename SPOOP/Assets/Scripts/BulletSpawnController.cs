using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnController : MonoBehaviour 
{
    // object to follow (player)
    // object is separate from player to ignore rotations
    // attach to empty object with tag "Bullet Spawn"
    private GameObject player;
    private Vector3 offset;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
    }
}