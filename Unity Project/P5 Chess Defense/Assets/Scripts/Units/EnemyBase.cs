using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Units
{
    Transform navemeshTarget;
    NavMeshAgent enemyModel;
    public int enemyMoveSpeed;

    public int enemyDamage;
    //all of following variables recieved through poison dart
    public bool isPoisoned;
    public int poisonDamage;
    public float timeOfPoison;
    float poisonTimer;
    public int poisonTicks;

    void Start()
    {
        navemeshTarget = GameObject.FindWithTag("Wizard").transform;
        this.GetComponent<NavMeshAgent>().speed = enemyMoveSpeed;
        EnemyMove();
    }

    void Update()
    {
        if (isPoisoned == true)
        {
            poisonTimer += Time.deltaTime;
            IsPoisoned();
        }
    }

    public void EnemyMove()
    {
        enemyModel = this.GetComponent<NavMeshAgent>();
        enemyModel.destination = navemeshTarget.position;
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == ("Wizard"))
        {
            Debug.Log("endpoint");
            target.gameObject.GetComponent<WizardScript>().TakeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }

    public virtual void IsPoisoned()
    {
        if (poisonTimer >= timeOfPoison)
        {
            //add particals
            health -= poisonDamage;
            poisonTimer = 0;
            poisonTicks -= 1;
            Death();
            if (poisonTicks <= 0)
            {
                isPoisoned = false;
            }
        }
    }
    public override void Death()
    {
        //change particals and sound
        base.Death();
    }

}
