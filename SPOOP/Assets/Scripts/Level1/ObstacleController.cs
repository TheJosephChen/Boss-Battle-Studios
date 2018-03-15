using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour 
{
    public float speed;
    private Vector3 startPosition;

    void Start () 
    {
        GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().obstacle = gameObject;
        gameObject.SetActive (false); //make sure object starts inactive
        startPosition = transform.position;
    }

    void Update () 
    {
        if (gameObject.activeSelf == true) //if object is active, player must have stepped on trigger, so move
            transform.Translate(0f, 0f, speed * Time.deltaTime * -1);
    }

    public void resetPos()
    {
        transform.position = startPosition;
    }
}
