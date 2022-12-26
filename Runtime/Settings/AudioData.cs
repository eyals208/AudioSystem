using UnityEngine;

public abstract class AudioData : ScriptableObject
{
    public abstract void UpdateMusicVolume(bool value);
    public abstract void UpdateMusicVolume(float value);
    public abstract void UpdateSFXVolume(bool value);
    public abstract void UpdateSFXVolume(float value);
}
