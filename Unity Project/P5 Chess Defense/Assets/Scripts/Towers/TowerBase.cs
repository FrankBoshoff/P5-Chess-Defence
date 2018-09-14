using System.Collections;
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
	void Update () {
		
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
