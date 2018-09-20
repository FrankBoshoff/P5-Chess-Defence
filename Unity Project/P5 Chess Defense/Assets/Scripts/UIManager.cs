using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public int waveNumber;
    public Text waveText;
    public int cash;
    public Text cashText;
    public GameObject pauseMenu;
    public Button continueButton;
    public Button exitButton;

	// Use this for initialization
	void Start () {
        continueButton.onClick.AddListener(Continue);
        exitButton.onClick.AddListener(Exit);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            print("pause");
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
	}

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateWaveUI()
    {
        waveNumber += 1;
        waveText.GetComponent<Text>().text = "Wave: " + waveNumber.ToString();
    }

    public void UpdateEconomyUI(int change)
    {
        cash += change;
        cashText.GetComponent<Text>().text = "Cash: " + cash.ToString();
    }
}
