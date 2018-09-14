using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : TowerBase {

    public Shot s;
    public Shot shot;
    public GameObject spawner;
    public int damage;

	// Use this for initialization
	void Start () {
		
	}

    public override void Ability()
    {
        spawner.GetComponent<SpawnSpazzer>().Shoot(targets[0], damage);
    }
}
