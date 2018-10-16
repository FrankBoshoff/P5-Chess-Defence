using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSoundObjS : MonoBehaviour
{
    public AudioSource enemyASource;
    public AudioClip enemyAClip;
    public float destroyTime;

    void Start()
    {
        DeathSoundObjFunction(enemyAClip);
        Destroy(gameObject, destroyTime);
    }

    public void DeathSoundObjFunction(AudioClip ad)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(enemyASource, ad);
    }

}
