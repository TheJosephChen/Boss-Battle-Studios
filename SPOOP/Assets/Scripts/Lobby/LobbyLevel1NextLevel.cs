using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyLevel1NextLevel : MonoBehaviour {

    void OnTriggerEnter(BoxCollider level1)
    {
        SceneManager.LoadScene("Level 1");
    }
}
