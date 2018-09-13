using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    Transform navemeshTarget;
    NavMeshAgent enemyModel;
    public int enmyMoveSpeed;

    public int enemyHeath;
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

    void OnCollisionEnter(Collision colwizard)
    {
        if (colwizard.gameObject.tag == ("Wizard"))
        {
            Debug.Log("endpoint");

            colwizard.gameObject.GetComponent<WizardScript>().wizardHealth -= enemyDamage;
            Destroy(gameObject);
        }
    }

    public void IsPoisoned()
    {
        if (poisonTimer >= timeOfPoison)
        {
            //add particals
            enemyHeath -= poisonDamage;
            poisonTimer = 0;
            poisonTicks -= 1;
            EnemyDeath();
            if (poisonTicks <= 0)
            {
                isPoisoned = false;
            }
        }
    }
    
    public virtual void EnemyDeath()
    {
        if (enemyHeath <= 0)
        {
            //particals and sound
            Destroy(gameObject);
        }
    }

}
