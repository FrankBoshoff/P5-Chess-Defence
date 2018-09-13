using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public bool direct;
    public Transform target;
    public int damage;
    public Vector3 v;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(direct == false)
        {
            transform.position += v;
        }
        else
        {
            
        }
	}
}
