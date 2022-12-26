using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXVolumeChangesHandler : SliderManager
{
    [SerializeField]
    private float _defaultValue = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // set the 3rd parameter to the value you want to initialize the volume slider with (0 - 1)
        InitializeSlider(_defaultValue, UpdateDataObject, _defaultValue);
    }

    private void UpdateDataObject(float value)
    {
        AudioManager.instance.AdjustSFXVolume(value);
    }
}
