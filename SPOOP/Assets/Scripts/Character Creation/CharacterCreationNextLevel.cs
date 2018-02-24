using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreationNextLevel : MonoBehaviour
{
    public GameObject character;

    public void OnMouseButton()
    {
        GameObject child = null;
        for (int i = 0; i < character.transform.childCount; i++)
        {
            var temp = character.transform.GetChild (i);
            if (temp.gameObject.activeSelf)
            {
                child = temp.gameObject;
                child.transform.SetParent (null);
            }
        }
        child.transform.position = new Vector3 (-1, 5, -42);
        child.GetComponent<Rigidbody>().useGravity = true;
        child.GetComponent<PlayerController> ().isGrounded = false;
        DontDestroyOnLoad (child);
        SceneManager.LoadScene("Lobby");
    }
}
