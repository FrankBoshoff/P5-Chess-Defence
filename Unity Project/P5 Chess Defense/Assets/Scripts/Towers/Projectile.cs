using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : TowerBase {

    public Shot shot;
    public GameObject spawner;
    public int damage;
    public int shotSpeed;

	// Use this for initialization
	void Start () {
		
	}

    public override void Ability()
    {
        spawner.GetComponent<SpawnSpazzer>().Shoot(shot, targets[0], damage, shotSpeed, false, false);
    }
}
