using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{

    public GameObject shop;
    public GameObject sell;
    public GameObject manager;
    public int lightMultiplier;
    private float rotation;
    private Vector3 v;
    private GameObject g;

    public GameObject noManaText;
    //public AudioSource buildSource;
    //public AudioClip build;

    public List<GameObject> Towers = new List<GameObject>();

    // Use this for initialization
    void Start () {
        rotation = Random.Range(0, 360);
        v.y = rotation;
        transform.eulerAngles = v;
        noManaText = GameObject.FindWithTag("NoMana");
        noManaText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(shop.activeSelf == false)
            {
                manager.GetComponent<UIManager>().shop = gameObject;
                shop.transform.position = Input.mousePosition;
                shop.SetActive(true);
            }
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<Light>().intensity *= lightMultiplier;
    }

    private void OnMouseExit()
    {
        GetComponent<Light>().intensity /= lightMultiplier;
    }

    public void BuildTower(Transform t, GameObject tower)
    {
        if(tower.GetComponent<TowerBase>().cost <= manager.GetComponent<UIManager>().cash && Time.timeScale != 0)
        {
            //GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(buildSource, build);
            manager.GetComponent<UIManager>().UpdateEconomyUI(-tower.GetComponent<TowerBase>().cost);
            g = Instantiate(tower, t.position, Quaternion.identity);
            g.GetComponent<TowerBase>().TowerStart();
            g.GetComponent<TowerBase>().uiManager = manager;
            g.GetComponent<TowerBase>().shopMenu = shop;
            g.GetComponent<TowerBase>().sellMenu = sell;
            g.GetComponent<TowerBase>().buildPoint = gameObject;
            gameObject.SetActive(false);
            CloseShop();
        }
        else
        {
            print("not enough cash");
            noManaText.SetActive(true);
            StartCoroutine(NoManaReset());
        }
    }

    IEnumerator NoManaReset()
    {
        yield return new WaitForSeconds(1.5f);
        noManaText.SetActive(false);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
