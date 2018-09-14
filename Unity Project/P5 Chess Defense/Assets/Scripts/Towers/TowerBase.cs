﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    public int cost;
    public int range;
    public float timer;
    public List<Transform> targets = new List<Transform>();

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SphereCollider>().radius = range;
        timer = 0;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0;
        }
        if(targets[0] != null && timer <= 0)
        {
            Ability();
        }
	}

    public virtual void Ability()
    {
        //tower attack/effect goes here
    }

    private void OnTriggerEnter(Collider collision)
    {
        //add enemy to target list
        targets.Add(collision.transform);
    }

    private void OnTriggerExit(Collider collision)
    {
        //remove enemy from target list
        targets.Remove(collision.transform);
    }
}
