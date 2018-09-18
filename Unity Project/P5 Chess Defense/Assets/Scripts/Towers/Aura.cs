using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : TowerBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Ability();
            timer = timerReset;
        }
    }
}
