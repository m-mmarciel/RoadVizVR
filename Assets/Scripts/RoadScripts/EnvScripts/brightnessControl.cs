﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is to be placed on the light as a method of controlling the brightness.
public class brightnessControl : MonoBehaviour
{
    [SerializeField] private Light sun;

    // Start is called before the first frame update
    //To begin with, get the object that the script is placed within
    void Start()
    {
        sun = GetComponent<Light>();
    }

    //Sets the intensity of the light
    void setBrightness(float inputBrightness)
    {
        sun.intensity = inputBrightness;
    }

    //Retrieves the current brightness setting
    float getBrightness()
    {
        return sun.intensity;
    }
}
