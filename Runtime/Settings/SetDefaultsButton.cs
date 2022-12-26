using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This script is on the set default button in the settings scene.
It defines the functionality of the button.
It finds all objects that inherit from the IUISettings interface 
and resets all settings values to the default values
*/
public class SetDefaultsButton : MonoBehaviour
{
    public void SetDefaults()
    {
        //AudioManager.instance.Play(""); uncomment and set the sound you want to play when reseting the settings
        var uiElements = FindObjectsOfType<MonoBehaviour>().OfType<IUISettings>();
        foreach(IUISettings element in uiElements)
        {
            element.SetToDefault();
        }
    }
}
