using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int health;
    public int damage;

    // Use this for initialization
    void Start () {
        SetValues();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Move ()
    {
        //movement code goes here
    }

    public virtual void SetValues ()
    {
        health = 1;
        damage = 1;
    }

    public virtual void Attack ()
    {
        //attack code here
    }

    public virtual void DoDamage ()
    {
        //damage code here
    }

    public virtual void OnDeath ()
    {
        //death code
    }

}
