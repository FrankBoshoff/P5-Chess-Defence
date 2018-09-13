using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int range;
    public float fireTimer;
    public float fireTimerReset;
    public int damage;
    public bool targeting;
    public Transform target;
    public GameObject spawner;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SphereCollider>().radius = range;
        fireTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer -= Time.deltaTime;
        if(fireTimer < 0)
        {
            fireTimer = 0;
        }
		if(targeting == true && fireTimer <= 0)
        {
            Fire();
        }
	}

    public virtual void Fire()
    {
        print("damage");
        spawner.GetComponent<SpawnSpazzer>().Shoot(target, damage, spawner.GetComponent<SpawnSpazzer>().spaz);
        fireTimer = fireTimerReset;
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
