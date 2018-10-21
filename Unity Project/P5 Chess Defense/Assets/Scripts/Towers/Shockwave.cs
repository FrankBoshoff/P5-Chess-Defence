using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Projectile
{
    public Blast blast;
    public Blast b;
    public int blastSpeed;
    public ParticleSystem ps;

    public AudioSource chargeSoundHolder;
    public AudioClip chargeSoundClip;
    public AudioClip chargeReleaseClip;
    public bool chargeBool = true;
    GameObject soundManagerHolder;

	// Use this for initialization
	void Start ()
    {
        soundManagerHolder = GameObject.FindWithTag("SoundManager");
        chargeSoundHolder = gameObject.GetComponentInChildren<AudioSource>();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Ability();
            ps.Play();
            timer = timerReset;
            soundManagerHolder.GetComponent<SoundManager>().PlaySound(chargeSoundHolder, chargeReleaseClip);
            chargeBool = true;
        }
        else
        {
            ChargeSoundFunction();
        }
    }

    public override void Ability()
    {
        b = Instantiate(blast, transform.position, Quaternion.identity);
        b.damage = damage;
        b.maxRange = range;
        b.speed = blastSpeed;
    }

    public void ChargeSoundFunction()
    {
        if (chargeBool == true)
        {
            soundManagerHolder.GetComponent<SoundManager>().PlaySound(chargeSoundHolder, chargeSoundClip);
            chargeBool = false;
        }
    }

}
