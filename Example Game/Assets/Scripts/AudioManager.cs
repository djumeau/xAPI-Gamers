using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public AudioSound[] Sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (AudioSound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    public void Play(string Name)
    {
        AudioSound s = Array.Find(Sounds, Sounds => Sounds.Name == Name);
        if (s != null)
        {
            s.Source.Play();
        } else
        {
            Debug.LogWarning("Sound not found [" + Name + "]");
        }
        
    }

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("theme");
    }

}
