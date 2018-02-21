using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyLevel1NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        DontDestroyOnLoad (other.gameObject);
        SceneManager.LoadScene("Level 1");
    }
}
