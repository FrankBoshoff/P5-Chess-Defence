using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource b;
    public AudioSource waveStart;
    public AudioClip nextWaveSound;

    private void Start()
    {
        b.Play();
        waveStart = gameObject.GetComponentInChildren<AudioSource>();
    }

    public void PlaySound()
    {
        waveStart.PlayOneShot(nextWaveSound);
    }

}
