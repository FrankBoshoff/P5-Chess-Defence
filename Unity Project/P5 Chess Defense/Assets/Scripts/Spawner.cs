using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyHolder;
    public float spawntime;
    public bool maySpawn;
    public GameObject manager;
    public GameObject ui;

    public GameObject rEnemy;
    GameObject e;

    void Start()
    {
        //maySpawn = true;
    }

    void Update()
    {
        if (maySpawn == true)
        {
            maySpawn = false;
            RendomEnemy();
        }
    }

    public void RendomEnemy()
    {
        rEnemy = enemyHolder[Random.Range(0, enemyHolder.Count)];
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawntime);
        e = Instantiate(rEnemy, transform.position, Quaternion.identity);
        e.GetComponent<EnemyBase>().wave = manager;
        e.GetComponent<EnemyBase>().ui = ui;
        manager.GetComponent<WaveManager>().toSpawn -= 1;
        manager.GetComponent<WaveManager>().toKill += 1;
        manager.GetComponent<WaveManager>().NextSpawn();
    }
}
