using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public GameObject door;

    void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
            door.transform.position = new Vector3(13.5f, 18, 78);
    }
}
