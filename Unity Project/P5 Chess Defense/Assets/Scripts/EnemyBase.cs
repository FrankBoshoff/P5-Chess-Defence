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

    void Start()
    {
        navemeshTarget = GameObject.FindWithTag("Wizard").transform;
        EnemyMove();
    }

    void Update()
    {
        
    }

    public virtual void EnemyMove()
    {
        enemyModel = this.GetComponent<NavMeshAgent>();
        enemyModel.destination = navemeshTarget.position;

    }
}
