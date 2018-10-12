using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSoundObjS : MonoBehaviour
{
    public AudioSource enemyASource;
    public AudioClip enemyAClip;

    void Start()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(enemyASource, enemyAClip);
    }

    void Update()
    {

    }

}
