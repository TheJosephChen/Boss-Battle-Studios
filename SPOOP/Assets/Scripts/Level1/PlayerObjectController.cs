using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectController : MonoBehaviour
{
	void Start ()
    {
        GameObject.FindWithTag ("Player").gameObject.transform.SetParent (transform);
	}
}
