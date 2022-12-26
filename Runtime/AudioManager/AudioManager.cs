using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; 
        }

        
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start() {
        Play("ThemeMusic");
    }
    
    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("sound " + name + " could not be found");
            return;
        }
        
        s.source.Play();
    }   

    public void AdjustSFXVolume(float value)
    {
        foreach(Sound s in sounds)
        {
            if(s.isSFX)
            {
                s.source.volume = value;
            }
        }
    }

    public void AdjustSFXVolume(bool value)
    {
        foreach(Sound s in sounds)
        {
            if(s.isSFX)
            {
                s.source.mute = value;
            }
        }
    }

    public void AdjustMusicVolume(float value, string name = "ThemeMusic")
    {
        Sound music = Array.Find(sounds, sound => sound.name == name);
        if (music == null) return;
        music.source.volume = value;
    }

    public void AdjustMusicVolume(bool mute, string name = "ThemeMusic")
    {
        Sound music = Array.Find(sounds, sound => sound.name == name);
        if (music == null) return;

        music.source.mute = mute;
    }
    
}
