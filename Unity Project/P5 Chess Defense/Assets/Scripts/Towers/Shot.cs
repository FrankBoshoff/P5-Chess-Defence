using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public int damage;
    public int speed;
    public bool poisonous;
    public bool explosive;
    public Transform target;
    public float lifeTimer;
    public Blast blast;
    public Blast b;

    // Use this for initialization
    void Start () {
        transform.LookAt(target);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(transform.forward * speed * Time.deltaTime);
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(poisonous == true)
            {
                collision.gameObject.GetComponent<EnemyBase>().isPoisoned = poisonous;
            }
            if(explosive == true)
            {
                //spawn explosion
                b = Instantiate(blast, transform.position, Quaternion.identity);
                b.damage = damage;
            }
            else
            {
                collision.gameObject.GetComponent<Units>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
