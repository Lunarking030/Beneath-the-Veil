using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{
    public int numEnemiesToSpawn;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public int numWaves;
    public int enemiesPerWave;
    public float delayBetweenWaves;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SpawnEnemiesInWaves());
            for (int i = 0; i < numEnemiesToSpawn; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                enemy.SetActive(true);
            }
        }
    }

    IEnumerator SpawnEnemiesInWaves()
    {
        for (int wave = 0; wave < numWaves; wave++)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                enemy.SetActive(true);
                yield return new WaitForSeconds(0.5f); // delay between spawning enemies in a wave
            }
            yield return new WaitForSeconds(delayBetweenWaves); // delay between waves
        }
    }
}
