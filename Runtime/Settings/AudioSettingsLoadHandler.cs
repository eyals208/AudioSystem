using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script should be on an object in the first scene of the game.
It loads the audio settings from an AudioData object to the AudioManager.
*/
public class AudioSettingsLoadHandler : MonoBehaviour
{
    [SerializeField]
    AudioData audioData;
    
    /// <summary>
    /// Loads user audio settings to the Audio Manager
    /// Call right after loading user data to AudioData object
    /// </summary>
    public void LoadAudioSettingToManager()
    {
        AudioManager.instance.AdjustMusicVolume(audioData.MusicVolume);
        AudioManager.instance.AdjustMusicVolume(audioData.IsMusicMuted);
        AudioManager.instance.AdjustSFXVolume(audioData.SFXVolume);
        AudioManager.instance.AdjustSFXVolume(audioData.IsSFXMuted);
    }

}
