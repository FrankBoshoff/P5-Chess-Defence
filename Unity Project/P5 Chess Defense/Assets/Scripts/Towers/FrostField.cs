using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostField : Aura {

    public int slow;

	// Use this for initialization
	void Start () {
		
	}

    public override void Ability()
    {
        foreach (Transform t in targets)
        {
            t.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
            t.gameObject.GetComponent<EnemyBase>().enemyMoveSpeed /= slow;
        }
    }

    public override void RemoveTarget(Transform t)
    {
        t.gameObject.GetComponent<EnemyBase>().enemyMoveSpeed *= slow;
        base.RemoveTarget(t);
    }
}
