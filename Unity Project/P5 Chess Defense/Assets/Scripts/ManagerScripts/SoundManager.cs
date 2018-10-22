using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource b;

    private void Start()
    {
        b.Play();
    }

    public void PlaySound(AudioSource s, AudioClip a)
    {
        s.PlayOneShot(a);
    }

}
