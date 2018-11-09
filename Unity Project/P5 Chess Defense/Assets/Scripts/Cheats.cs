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
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Comma) && Time.timeScale != 0)
        {
            Debug.Log("01");
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Period) && Time.timeScale != 0)
        {
            Debug.Log("02");
            Time.timeScale = 2;
        }
        if (Input.GetKeyDown(KeyCode.Slash) && Time.timeScale != 0)
        {
            Debug.Log("03");
            Time.timeScale = 1;
        }
        if (Input.GetKey(KeyCode.Semicolon) && Time.timeScale != 0)
        {
            Debug.Log("04");
            manager.GetComponent<UIManager>().UpdateEconomyUI(5);
        }
    }
}
