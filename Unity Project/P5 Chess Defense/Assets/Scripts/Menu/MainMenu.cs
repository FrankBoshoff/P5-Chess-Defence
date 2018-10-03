using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button start;
    public Button options;
    public Button exit;
    public Button gallery;

	// Use this for initialization
	void Start () {
        start.onClick.AddListener(StartGame);
        options.onClick.AddListener(Options);
        exit.onClick.AddListener(ExitGame);
        gallery.onClick.AddListener(Gallery);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        print("start game");
        SceneManager.LoadScene("Jorrit(Kopie)");
    }

    public void Options()
    {
        print("options");
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        print("exit");
        Application.Quit();
    }

    public void Gallery()
    {
        SceneManager.LoadScene("ArtRoom");
    }
}
