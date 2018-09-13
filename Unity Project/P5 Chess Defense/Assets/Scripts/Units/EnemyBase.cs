using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Units
{
    Transform navemeshTarget;
    NavMeshAgent enemyModel;
    public int enmyMoveSpeed;

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
            target.gameObject.GetComponent<WizardScript>().health -= enemyDamage;
            Destroy(gameObject);
            //apart gameover of met deathfunction
            target.gameObject.GetComponent<WizardScript>().GameOver();
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
    
    public virtual void Death()
    {
        if (health <= 0)
        {
            //particals and sound
            Destroy(gameObject);
        }
    }

}
