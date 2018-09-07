using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetValues ()
    {
        damage = 1;
        health = 10;
    }

    public void SetTurn ()
    {
        turn = true;
    }
}
