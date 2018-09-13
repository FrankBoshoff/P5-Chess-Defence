using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int range;
    public float fireTimer;
    public int damage;
    public bool targeting;
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer += Time.deltaTime;
		if(targeting == true && fireTimer >= 0.5)
        {
            Fire();
        }
	}

    public void Fire()
    {
        print("damage");
        fireTimer = 0;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (targeting == false)
        {
            target = collision.transform;
            targeting = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        targeting = false;
    }
}
