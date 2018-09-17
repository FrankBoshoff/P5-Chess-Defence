using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyHolder;
    public float spawntime;
    public bool maySpawn;
    GameObject rEnemy;

    void Start()
    {
        maySpawn = true;
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
        Instantiate(rEnemy, transform.position, Quaternion.identity);
        maySpawn = true;
    }
}
