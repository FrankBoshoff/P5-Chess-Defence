using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpazzer : MonoBehaviour
{

    public Vector3 v;
    public float var;
    public Transform t;
    public bool spaz;
    public Shot shot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(spaz == true)
        {
            v.x = Random.Range(t.position.x - var, t.position.x + var);
            v.z = Random.Range(t.position.z - var, t.position.z + var);
            transform.position = v;
        }
    }

    public void Shoot(Shot s, Transform target, int damage, int speed, bool explosion, bool poison, int ticks)
    {
        shot = Instantiate(s, transform.position, Quaternion.identity);
        shot.damage = damage;
        shot.speed = speed;
        shot.target = target;
        shot.explosive = explosion;
        shot.poisonous = poison;
        shot.ticks = ticks;
    }
}
