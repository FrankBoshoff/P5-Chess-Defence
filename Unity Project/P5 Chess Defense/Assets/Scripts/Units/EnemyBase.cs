using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Units
{
    Transform navemeshTarget;
    NavMeshAgent enemyModel;
    public ParticleSystem poisonParticals;
    public int enemyMoveSpeed;
    public GameObject wave;
    public GameObject ui;
    public int minWorth;
    public int maxWorth;

    public int enemyDamage;
    //all of following variables recieved through poison dart
    public bool isPoisoned;
    public int poisonDamage;
    public float timeOfPoison;
    float poisonTimer;
    public int poisonTicks;
    public List<GameObject> towers = new List<GameObject>();

    void Start()
    {
        poisonParticals.Pause();
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
            poisonParticals.Play();
            Debug.Log(poisonParticals);
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

            poisonTimer = 0;
            poisonTicks -= 1;
            if (poisonTicks <= 0)
            {
                isPoisoned = false;
                poisonParticals.Stop();
                Debug.Log(poisonParticals+"stop");

            }
            TakeDamage(poisonDamage);
        }
    }

    public override void Death()
    {
        //change particals and sound
        foreach(GameObject g in towers)
        {
            g.GetComponent<TowerBase>().RemoveTarget(gameObject.transform);
        }
        poisonParticals.Stop();
        wave.GetComponent<WaveManager>().toKill -= 1;
        ui.GetComponent<UIManager>().UpdateEconomyUI(Random.Range(minWorth, maxWorth));
        base.Death();
    }
}
