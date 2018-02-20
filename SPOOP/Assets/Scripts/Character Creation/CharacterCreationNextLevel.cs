using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreationNextLevel : MonoBehaviour {

    public void OnMouseButton()
    {
        SceneManager.LoadScene("Lobby");
    }
}
