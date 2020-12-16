﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public int scene;

    public void SwitchScene(int scene)
    {
        
        SceneManager.LoadScene(scene);
    }
}
