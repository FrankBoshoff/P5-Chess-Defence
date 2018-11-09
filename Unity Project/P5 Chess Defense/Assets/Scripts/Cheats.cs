using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    private GameObject manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("UImanager");		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("Comma") && Time.timeScale != 0)
        {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyDown("Period") && Time.timeScale != 0)
        {
            Time.timeScale = 2;
        }
        if (Input.GetKeyDown("Slash") && Time.timeScale != 0)
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("Semicolon") && Time.timeScale != 0)
        {
            manager.GetComponent<UIManager>().UpdateEconomyUI(5);
        }
    }
}
