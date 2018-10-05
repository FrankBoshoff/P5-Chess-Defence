using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour {

    public GameObject shop;
    public GameObject manager;

    public List<GameObject> Towers = new List<GameObject>();

    // Use this for initialization
    void Start () {
        transform.eulerAngles(0, Random.Range(0.0f, 360.0f));
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

    public void BuildTower(Transform t, GameObject tower)
    {
        if(tower.GetComponent<TowerBase>().cost <= manager.GetComponent<UIManager>().cash)
        {
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
