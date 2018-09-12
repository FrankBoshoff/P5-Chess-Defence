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

    public bool isPoisoned;
    public int poisonDamage;

    void Start()
    {
        navemeshTarget = GameObject.FindWithTag("Wizard").transform;
        EnemyMove();
    }

    void Update()
    {
        if (isPoisoned == true)
        {
            IsPoisoned();
        }
    }

    public void EnemyMove()
    {
        enemyModel = this.GetComponent<NavMeshAgent>();
        enemyModel.destination = navemeshTarget.position;
    }

    public void IsPoisoned()
    {
        //enemyHeath -= poisonDamage //overtime
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
