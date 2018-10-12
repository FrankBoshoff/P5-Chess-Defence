using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public GameObject UImanager;
    public AudioSource wizardAudioSource;
    
    public void WizardSoundReceiver(AudioClip a)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(wizardAudioSource, a);
    }


    public override void Death()
    {
        //add/change particals and sound
        print("Game Over");
        base.Death();
    }
}
