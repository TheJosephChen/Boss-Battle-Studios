using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour 
{

	public float speed;

	void Start () 
	{
        GameObject.FindWithTag ("Player").GetComponent<PlayerController>().obstacle = gameObject;
        gameObject.SetActive (false); //make sure object starts inactive
	}

	void Update () 
	{
		if (gameObject.activeSelf == true) //if object is active, player must have stepped on trigger, so move
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime * -1);
		}
		
	}
}
