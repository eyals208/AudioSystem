using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This class is on the music volume game object in the settings scene.
the toggle component is a child of the game object holding this script.
This script inherits from the CheckBoxManager, that does most of the handling of the toggle.
This script initializes the CheckBoxManager and updates the 
Audio manager and the scriptable data object when the check box value changes
*/
public class MusicToggle : CheckBoxManager
{   
    [SerializeField]
    private bool _defaultValue = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeToggle(_defaultValue, UpdateDataObject);
    }

    private void UpdateDataObject(bool value)
    {
        if(audioData != null)
            audioData.UpdateSFXVolume(value);

        else
            Debug.LogWarning("Make sure you assign an AudioData object so your setting are saved when changed");

        if (AudioManager.instance != null)
            AudioManager.instance.AdjustSFXVolume(value);

        else
            Debug.LogWarning("Please an Audio Manager to the scene");
    }
}
