using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Units
{
    Transform navemeshTarget;
    NavMeshAgent enemyModel;
    ParticleSystem poisonParticals;
    public int enemyMoveSpeed;
    public GameObject wave;
    public GameObject ui;
    public int worth;
    public int minWorth;
    public int maxWorth;

    public AudioClip wizardDamageSoundHolder;
    public GameObject soundObjectHolder;
    public GameObject popUpTextPrefab;

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
        worth = Random.Range(minWorth, maxWorth);

        poisonParticals = this.GetComponentInChildren<ParticleSystem>();//
        poisonParticals.Pause();//

        navemeshTarget = GameObject.FindWithTag("Wizard").transform;
        EnemyMove();
    }

    void Update()
    {
        this.GetComponent<NavMeshAgent>().speed = enemyMoveSpeed;
        if (isPoisoned == true)
        {
            poisonTimer += Time.deltaTime;
            IsPoisoned();
            poisonParticals.Play();//
        }
        else
        {
            poisonParticals.Stop();//
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
            target.gameObject.GetComponent<WizardScript>().WizardSoundReceiver(wizardDamageSoundHolder);
            target.gameObject.GetComponent<WizardScript>().TakeDamage(enemyDamage);
            minWorth = 0;
            maxWorth = 0;
            Death();
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
                //poisonParticals.Pause();
            }
            TakeDamage(poisonDamage);
        }
    }

    public override void Death()
    {
        ShowFloatingText();
        Instantiate(soundObjectHolder, transform.position, transform.rotation);
        foreach (GameObject g in towers)
        {
            g.GetComponent<TowerBase>().RemoveTarget(gameObject.transform);
        }
        wave.GetComponent<WaveManager>().toKill -= 1;
        ui.GetComponent<UIManager>().UpdateEconomyUI(worth);
        base.Death();
    }

    public void ShowFloatingText()
    {
        var go = Instantiate(popUpTextPrefab, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = worth.ToString() + "+ ";
    }

}
