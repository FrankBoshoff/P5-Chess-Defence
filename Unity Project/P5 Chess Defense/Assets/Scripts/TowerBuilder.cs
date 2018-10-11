using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    public GameObject shop;
    public GameObject manager;
    public int lightMultiplier;
    private float rotation;
    private Vector3 v;

    //public AudioSource buildSource;
    //public AudioClip build;

    public List<GameObject> Towers = new List<GameObject>();

    // Use this for initialization
    void Start () {
        rotation = Random.Range(0, 360);
        v.y = rotation;
        transform.eulerAngles = v;
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
        if(tower.GetComponent<TowerBase>().cost <= manager.GetComponent<UIManager>().cash)
        {
            //GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(buildSource, build);
            manager.GetComponent<UIManager>().UpdateEconomyUI(-tower.GetComponent<TowerBase>().cost);
            Instantiate(tower, t.position, Quaternion.identity);
            gameObject.SetActive(false);
            CloseShop();
        }
        else
        {
            print("not enough cash");
        }
    }

    public void CloseShop()
    {
        print("SHOP CLOSE");
        shop.SetActive(false);
    }
}
