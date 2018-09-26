using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Projectile {

    public Blast blast;
    public Blast b;
    public int blastSpeed;
    public ParticleSystem ps;

	// Use this for initialization
	void Start () {
		
	}

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Ability();
            ps.Play();
            timer = timerReset;
        }
    }

    public override void Ability()
    {
        b = Instantiate(blast, transform.position, Quaternion.identity);
        b.damage = damage;
        b.maxRange = range;
        b.speed = blastSpeed;
    }
}
