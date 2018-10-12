using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public GameObject UImanager;

    public AudioSource wSource;

    public void WizardSoundFunction(AudioClip aWiz)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(wSource, aWiz);
    }

    public override void Death()
    {
        //add/change particals and sound
        print("Game Over");
        base.Death();
    }
}
