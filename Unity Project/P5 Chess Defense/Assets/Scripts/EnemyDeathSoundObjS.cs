using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSoundObjS : MonoBehaviour
{
    public AudioSource enemyASource;
    public AudioClip enemyAClip;

    void Start()
    {
        DeathSoundObjFunction(enemyAClip);
        Destroy(gameObject, 8);
    }

    public void DeathSoundObjFunction(AudioClip ad)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(enemyASource, ad);
    }

}
