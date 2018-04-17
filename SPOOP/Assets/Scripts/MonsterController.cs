using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    public GameObject monster;

    void Start()
    {
        monster.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                bool isActive = monster.gameObject.activeSelf;
                monster.gameObject.SetActive(!isActive);
             
            }
        }
    }