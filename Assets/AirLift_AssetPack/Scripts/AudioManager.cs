using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public AudioMixerGroup mixerGroup;
        public bool playOnAwake;
        public bool loop;
        [HideInInspector]
        public AudioSource source;
    }


    public List<Sound> sounds = new List<Sound>();

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Create AudioSources for each Sound object
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Play();
    }

    public void Pause(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Pause();
    }

    public void Stop(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Stop();
    }

    public void pauseSounds()
    {



        // Pause all playing sounds
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Pause();
            }
        }

    }
    public void unpauseSounds()
    {
        

        // Resume paused sounds
        foreach (Sound s in sounds)
        {
            if (s.source.clip != null && s.source.time != 0 && !s.source.isPlaying)
            {
                s.source.UnPause();
            }
        }
    }


}    
















