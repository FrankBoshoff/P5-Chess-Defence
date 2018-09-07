using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : Enemy
{
    Vector3 pawnMoveForward;

    // Use this for initialization
    void Start()
    {
        pawnMoveForward.x += -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Move()
    {
        if (manager.  == false)
        {
            transform.Translate(pawnMoveForward * Time.deltaTime);
            //moet nog verzinnen om allemaal te checken
            manager.turn = true;
        }
    }
}
