using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SliderManager : MonoBehaviour, IUISettings
{
    [SerializeField]
    protected AudioData audioData; // dataObject inplementing IAudioData (to be updated when settings changed)
    private Slider slider;
    private float defaultValue;
    
    public void InitializeSlider(float _defaultValue, UnityAction<float> valueChangedAction, float value = 0.5f)
    {
        slider = gameObject.GetComponentInChildren(typeof(Slider)) as Slider;
        if(slider != null)
        {
            slider.value = value;
            slider.onValueChanged.AddListener(valueChangedAction);
            defaultValue = _defaultValue;
        }
        else
            Debug.Log("cannot find " +gameObject.name + " slider");
    }

    public void SetToDefault()
    {
        slider.value = defaultValue;
    }
}
