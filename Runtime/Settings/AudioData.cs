using UnityEngine;

public abstract class AudioData : ScriptableObject
{
    bool isMusicMuted = false;
    float musicVolume = 0.5f;
    bool isSFXMuted = false;
    float sfxVolume = 0.5f;
    public virtual bool IsMusicMuted 
    {   get => isMusicMuted;
        set => isMusicMuted = value; 
    }
    public virtual float MusicVolume
    {
        get => musicVolume;
        set => musicVolume = value;
    }
    public virtual bool IsSFXMuted
    {
        get => isSFXMuted;
        set => isSFXMuted = value;
    }
    public virtual float SFXVolume
    {
        get => sfxVolume;
        set => sfxVolume = value;
    }
}
