using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip Background;
    public AudioClip Engine;
    public AudioClip EngineRunning;

    private void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayEngineSound(AudioClip clip)
    {
        if (SFXSource.clip != clip)
        {
            SFXSource.Stop();
            SFXSource.clip = clip;
            SFXSource.loop = true;
            SFXSource.Play();
        }
    }
}
