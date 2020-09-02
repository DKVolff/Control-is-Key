using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioManager instance;
    public Sound currentlyPlaying;
    public Sound fadePlaying;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    void Update()
    {
        if (currentlyPlaying != null)
        {
            //if (currentlyPlaying.source.volume < 1)
            //    currentlyPlaying.source.volume += Time.deltaTime;
        }
    }

    public void Play(string name)
    {
        currentlyPlaying = Array.Find(sounds, sound => sound.name == name);
        currentlyPlaying.source.Play();
    }


    public void Stop(string name)
    {
        fadePlaying = Array.Find(sounds, sound => sound.name == name);
        while (fadePlaying.source.volume > 0)
        {
            fadePlaying.source.volume -= Time.deltaTime / 3;
        }
    }

    // public void Stop(string name)
    // {
    //     Sound s = Array.Find(sounds, sound => sound.name == name);
    //     if (s == null)
    //     {
    //         Debug.LogWarning("Sound: " + name + " not found!");
    //         return;
    //     }
    //     s.source.Stop();
    // }
}