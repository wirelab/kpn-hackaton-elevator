﻿
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {

        foreach (Sound s in sounds) {
           AudioSource audioSource = gameObject.AddComponent<AudioSource>();
           s.source = audioSource;
           s.source.clip = s.clip;
           s.source.pitch = s.pitch;
           s.source.volume = s.volume; 
        }
        
    }

    private void Start()
    {
     // Play("ambient");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }
}