using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    public Button back;

	// Use this for initialization
	void Start () {
        back.onClick.AddListener(ToMainMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
