using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public int damage;
    public int speed;
    public bool poisonous;
    public bool explosive;
    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(transform.forward * speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Units>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
