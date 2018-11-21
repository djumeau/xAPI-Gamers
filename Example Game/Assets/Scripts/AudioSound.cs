using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioSound {

    public string Name;

    public AudioClip Clip;

    public bool Loop = false;

    [Range(0f, 1f)]
    public float Volume;

    [Range(0.1f, 3.0f)]
    public float Pitch;

    [HideInInspector]
    public AudioSource Source;

}
