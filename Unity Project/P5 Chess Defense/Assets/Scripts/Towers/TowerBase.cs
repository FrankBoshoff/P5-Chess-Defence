using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    public int cost;
    public int damage;
    public int range;
    public float timer;
    public float timerReset;
    public List<Transform> targets = new List<Transform>();
    public GameObject shopMenu;
    public GameObject sellMenu;
    public GameObject uiManager;
    public GameObject buildPoint;
    private GameObject g;

    public AudioSource buildSource;
    public AudioClip build;
    AudioSource sellSource;
    public AudioClip sellCilp;
    public GameObject sellSoundObj;
    public ParticleSystem buildPar;
    public ParticleSystem SellPar;

    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<SphereCollider>().radius = range;
        timer = 0;
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(buildSource, build);
        sellSource = sellSoundObj.GetComponent<AudioSource>();
        buildPar.Play();
    }
	
	// Update is called once per frame
	public virtual void Update ()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0;
        }
        if(targets.Count > 0)
        {
            if (targets[0] != null && timer <= 0)
            {
                Ability();
                timer = timerReset;
            }
        }
	}

    public virtual void Ability()
    {
        //tower attack/effect goes here
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (!targets.Contains(collision.transform))
            {
                AddTarget(collision.transform);
            }
            if (!collision.GetComponent<EnemyBase>().towers.Contains(gameObject))
            {
                collision.GetComponent<EnemyBase>().towers.Add(gameObject);
            }
        }
        //add enemy to target list
        /*if (!targets.Contains(collision.transform))
        {
            AddTarget(collision.transform);
        }
        if (!collision.GetComponent<EnemyBase>().towers.Contains(gameObject))
        {
            collision.GetComponent<EnemyBase>().towers.Add(gameObject);
        }*/
    }

    private void OnTriggerExit(Collider collision)
    {
        if (targets.Contains(collision.transform))
        {
            RemoveTarget(collision.transform);
            collision.GetComponent<EnemyBase>().towers.Remove(gameObject);
        }
        //remove enemy from target list
        /*RemoveTarget(collision.transform);
        collision.GetComponent<EnemyBase>().towers.Remove(gameObject);*/
    }

    public virtual void RemoveTarget(Transform t)
    {
        targets.Remove(t);
    }

    public virtual void AddTarget(Transform t)
    {
        targets.Add(t);
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (sellMenu.activeSelf == false)
            {
                uiManager.GetComponent<UIManager>().seller = this.gameObject;
                sellMenu.transform.position = Input.mousePosition;
                sellMenu.SetActive(true);
            }
        }
    }

    public virtual void Sell()
    {
        uiManager.GetComponent<UIManager>().UpdateEconomyUI(cost / 2);
        buildPoint.SetActive(true);
        /*g = Instantiate(buildPoint, transform.position, Quaternion.identity);
        g.GetComponent<TowerBuilder>().shop = shopMenu;
        g.GetComponent<TowerBuilder>().sell = sellMenu;
        g.GetComponent<TowerBuilder>().manager = uiManager;*/
        sellMenu.SetActive(false);

        Instantiate(sellSoundObj, transform.position, Quaternion.identity);
        Instantiate(SellPar, transform.position, Quaternion.identity);
        //GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(sellSource, sellCilp);

        Destroy(gameObject);
    }
}
