﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public int waveNumber;
    public Text waveText;
    public int cash;
    public int startCash;
    public Text cashText;
    public GameObject pauseMenu;
    public Button continueButton;
    public Button exitButton;

    public GameObject shop;
    public Button shopTower1;
    public Button shopTower2;
    public Button shopTower3;
    public Button shopTower4;
    public Button shopTower5;
    public Button shopClose;

    public GameObject seller;
    public Button sell;
    public Button sellClose;

    public GameObject gameOver;

    // Use this for initialization
    void Start ()
    {
        continueButton.onClick.AddListener(Continue);
        exitButton.onClick.AddListener(Exit);
        shopTower1.onClick.AddListener(delegate { OrderTower(0); });
        shopTower2.onClick.AddListener(delegate { OrderTower(1); });
        shopTower3.onClick.AddListener(delegate { OrderTower(2); });
        shopTower4.onClick.AddListener(delegate { OrderTower(3); });
        shopTower5.onClick.AddListener(delegate { OrderTower(4); });
        shopClose.onClick.AddListener(CloseShop);
        sell.onClick.AddListener(SellTower);
        sellClose.onClick.AddListener(SellClose);
        UpdateEconomyUI(startCash);
    }
	
	// Update is called once per frame
	void Update ()
    {
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateWaveUI()
    {
        //waveNumber += 1;
        waveText.GetComponent<Text>().text = "Wave: " + waveNumber.ToString();
    }

    public void UpdateEconomyUI(int change)
    {
        cash += change;
        cashText.GetComponent<Text>().text = "Cash: " + cash.ToString();
    }

    public void OrderTower(int i)
    {
        shop.GetComponent<TowerBuilder>().BuildTower(shop.transform, shop.GetComponent<TowerBuilder>().Towers[i]);
    }

    public void SellTower()
    {
        seller.GetComponent<TowerBase>().Sell();
    }

    public void CloseShop()
    {
        print("SHOP SHUT");
        shop.GetComponent<TowerBuilder>().CloseShop();
    }

    public void SellClose()
    {
        seller.GetComponent<TowerBase>().sellMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
