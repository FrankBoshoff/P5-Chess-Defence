using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public int toSpawn;
    public int minimumEnemies;
    public int maximumEnemies;
    public int toKill;
    public float timer;
    public float timerReset;
    public GameObject spawner;
    public int increase;
    public int minimumIncrease;
    public int maximumIncrease;
    public GameObject uiManager;

	// Use this for initialization
	void Start ()
    {
        NewWave();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(toSpawn <= 0 && toKill <= 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                NewWave();
            }
        }
	}

    public void NewWave()
    {
        uiManager.GetComponent<UIManager>().UpdateWaveUI();
        increase = Random.Range(minimumIncrease, maximumIncrease);
        minimumEnemies += increase;
        maximumEnemies += increase;
        toSpawn = Random.Range(minimumEnemies, maximumEnemies);
        timer = timerReset;
        NextSpawn();

        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound();

    }

    public void NextSpawn()
    {
        if(toSpawn > 0)
        {
            spawner.GetComponent<Spawner>().maySpawn = true;
        }
        else
        {
            spawner.GetComponent<Spawner>().maySpawn = false;
        }
    }
}
