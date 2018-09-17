using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDart : Projectile {

	// Use this for initialization
	void Start () {
		
	}

    public override void Ability()
    {
        spawner.GetComponent<SpawnSpazzer>().Shoot(shot, targets[0], damage, shotSpeed, false, true);
    }
}
