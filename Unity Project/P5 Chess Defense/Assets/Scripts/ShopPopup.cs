﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : MonoBehaviour {

    public GameObject g;
    //public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayInfo()
    {
        if (g.activeSelf == false)
        {
            g.transform.position = Input.mousePosition;
            g.SetActive(true);
        }
    }

    public void RemoveInfo()
    {
        if (g.activeSelf == true)
        {
            g.SetActive(false);
        }
    }
}
