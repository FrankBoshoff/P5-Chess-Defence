using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpazzer : MonoBehaviour {

    public Vector3 v;
    public float var;
    public Transform t;
    public bool spaz;
    public Projectile p;
    public Projectile shot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(spaz == true)
        {
            v.x = Random.Range(t.position.x - var, t.position.x + var);
            v.z = Random.Range(t.position.z - var, t.position.z + var);
            transform.position = v;
        }
    }

    public void Shoot(Transform target, int damage, bool direct)
    {
        direct = !direct;
        shot = Instantiate(p, transform.position, Quaternion.identity);
        shot.damage = damage;
        shot.target = target;
        shot.direct = direct;
    }
}
