﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    public void doquit()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }
    

}
