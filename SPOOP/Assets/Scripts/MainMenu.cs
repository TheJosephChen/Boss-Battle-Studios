﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public bool Start;
    public bool Quit;

    void OnMouseUp()
    {
        if (Start)
        {
            
        }
        if (Quit)
        {
            Application.Quit();
        }
    }
}
