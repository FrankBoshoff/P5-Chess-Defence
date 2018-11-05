using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public GameObject UImanager;
    public GameObject deathSoundObjHolder;
    public AudioSource wizardAudioSource;
    public AudioClip wizardDeathSoundHolder;
    
    public void WizardSoundReceiver(AudioClip a)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(wizardAudioSource, a);
    }
    
    public override void Death()
    {
        deathSoundObjHolder.GetComponent<EnemyDeathSoundObjS>().DeathSoundObjFunction(wizardDeathSoundHolder);
        Instantiate(deathSoundObjHolder, transform.position, transform.rotation);
        print("Game Over");
        base.Death();
        UImanager.GetComponent<UIManager>().GameOver();
    }
}
