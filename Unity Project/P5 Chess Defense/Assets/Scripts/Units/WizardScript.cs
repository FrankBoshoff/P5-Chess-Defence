using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public GameObject UImanager;
    public GameObject DeathSoundObjHolder;
    public AudioSource wizardAudioSource;
    public AudioClip wizardDeathSoundHolder;
    
    public void WizardSoundReceiver(AudioClip a)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(wizardAudioSource, a);
    }
    
    public override void Death()
    {
        DeathSoundObjHolder.GetComponent<EnemyDeathSoundObjS>().DeathSoundObjFunction(wizardDeathSoundHolder);
        Instantiate(DeathSoundObjHolder, transform.position, transform.rotation);
        print("Game Over");
        base.Death();
    }
}
