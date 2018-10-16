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
    public int waveNrSpawnSpeedIncreaseModulo;
    public float spawnSpeedIncreaseMod;
    public GameObject spawner;
    public int increase;
    public int minimumIncrease;
    public int maximumIncrease;
    public GameObject uiManager;

    public AudioSource waveSource;
    public AudioClip waveSound;

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
        uiManager.GetComponent<UIManager>().waveNumber += 1;
        uiManager.GetComponent<UIManager>().UpdateWaveUI();
        if(uiManager.GetComponent<UIManager>().waveNumber % waveNrSpawnSpeedIncreaseModulo == 0)
        {
            spawner.GetComponent<Spawner>().spawntime *= spawnSpeedIncreaseMod;
        }
        increase = Random.Range(minimumIncrease, maximumIncrease);
        minimumEnemies += increase;
        maximumEnemies += increase;
        toSpawn = Random.Range(minimumEnemies, maximumEnemies);
        timer = timerReset;
        NextSpawn();

        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(waveSource, waveSound);

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
