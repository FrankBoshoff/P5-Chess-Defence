using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour {

    public int damage;
    public float range;
    public int speed;
    public float maxRange;

	// Use this for initialization
	void Start () {
        range = 0;
        gameObject.GetComponent<SphereCollider>().radius = range;
	}
	
	// Update is called once per frame
	void Update () {
        range += Time.deltaTime * speed;
        gameObject.GetComponent<SphereCollider>().radius = range;
        if(range >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyBase>().TakeDamage(damage);
        }
    }
}
