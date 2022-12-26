using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
This class is used as a base class to manage the volume and SFX mutability
This class is managing both the checkbox and the music/sfx icon
*/
public class CheckBoxManager : MonoBehaviour, IUISettings
{
    [SerializeField]
    private Sprite onImage;     // icon displayed when the music/sfx is on
    [SerializeField]
    private Sprite offImage;    // icon displayed when the music/sfx is off (muted)
    private Image image;        // the image component holding the icon
    private Toggle toggle;      // the toogle component for the check box
    private bool defaultValue;  // the default state of the checkbox
    
    // This function is called by the inhereting class to initialize the check box and its functionality
    public void InitializeToggle(bool _defaultValue, UnityAction<bool> valueChangedAction, bool value = false)
    {
        InitializeComponents();
        
        if(toggle != null && image != null)
        {
            toggle.onValueChanged.AddListener(valueChangedAction);
            toggle.onValueChanged.AddListener(ChangeImage);
            defaultValue = _defaultValue;
            SetImageNToggle(value);
        }
        else
            Debug.Log("cannot find " +gameObject.name + " toggle");
    }

    // This function gets the required components from the children of the game object
    void InitializeComponents()
    {
        toggle = GetComponentInChildren<Toggle>();
        image = GetComponentInChildren<Image>();
    }

    // This function is called during initialization to set right icon and checkbox state
    void SetImageNToggle(bool value)
    {
        toggle.isOn = value;
        ChangeImage(value);
    }

    // This function is inherited from the IUISettings interface to enable easy reseting to defaults
    public void SetToDefault()
    {
        toggle.isOn = defaultValue;
    }

    // This function updates the icon whenever the mute state changes
    void ChangeImage(bool value)
    {
        image.sprite = value? offImage : onImage;
    }

    // This function is called by the icons (when pressed) to change the mute state
    public void FlipValue()
    {
        toggle.isOn = !toggle.isOn;
    }

}
