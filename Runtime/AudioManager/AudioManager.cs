using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField][Tooltip("automatically plays music sources one after the other, plays on start. will override looped sources")]
    bool autoplay = true;
    public bool AutoPlay
    {
        get => autoplay;
        set => autoplay = value;
    }

    [SerializeField]
    public Sound[] sounds;

    List<Sound> musicSounds = new();

    Sound activeMusic;
    float lastTime;
    bool isMusicMute = false;
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

            if (!s.isSFX)
            {
                musicSounds.Add(s);
                s.source.loop = autoplay? false : s.loop;
            }
        }
    }

    private void Start() {
        if (autoplay && musicSounds.Count > 0)
        {
            activeMusic = musicSounds[0];
            activeMusic.source.Play();
        }
    }

    private void Update()
    {
        if (activeMusic == null || !autoplay || isMusicMute) return;
        if (IsDone(activeMusic.source))
            PlayNextMusic(activeMusic);
    }

    private void PlayNextMusic(Sound activeMusic)
    {
        int index = musicSounds.IndexOf(activeMusic);
        if (index >= musicSounds.Count - 1) index = 0;
        else index++;
        PlayMusic(musicSounds[index]);

    }

    bool IsDone(AudioSource audioSource)
    {
        if (audioSource.time < lastTime) return true;
        lastTime = audioSource.time;
        return false;
        //return audioSource.time >= audioSource.clip.length;
    }

    void PlayMusic(Sound sound)
    {
        if (isMusicMute) return;
        lastTime = -1;
        activeMusic.source.Stop();
        activeMusic = sound; ;
        activeMusic.source.Play();
        Debug.Log("playing " + activeMusic.name);
    }
    
    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("sound " + name + " could not be found");
            return;
        }

        if (!s.isSFX) PlayMusic(s);
        else s.source.Play();
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

    public void AdjustMusicVolume(float value)
    {
        foreach (Sound s in sounds)
        {
            if (!s.isSFX)
            {
                s.source.volume = value;
            }
        }
    }

    public void AdjustMusicVolume(bool value)
    {
        foreach (Sound s in sounds)
        {
            if (!s.isSFX)
            {
                s.source.mute = value;
            }
        }

        isMusicMute = value;
    }
    
}
