using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour 
{

	private List<GameObject> models;
	// Default Model selected
	private int selectionIndex = 0;

	// Use this for initialization
	void Start () 
	{
		models = new List<GameObject> ();
		foreach (Transform t in transform) {
			models.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}

		models [selectionIndex].SetActive (true);
	}

	public void Select (int index)
	{
		// do nothing if
		if (index == selectionIndex)
			return;
		if (index < 0|| index >= models.Count)
			return;
		
		// otherwise good index
		models[selectionIndex].SetActive(false);
		selectionIndex = index;
		models[selectionIndex].SetActive (true);
		
	}
}
