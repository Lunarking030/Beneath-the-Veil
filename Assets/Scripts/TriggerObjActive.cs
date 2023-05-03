using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{
    public int numEnemiesToSpawn;
    public GameObject enemyPrefab;
    public int numWaves;
    public int enemiesPerWave;
    public float delayBetweenWaves;
    public Vector3 spawnRange;

    private bool isSpawning = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnEnemiesInWaves());
        }
    }

    IEnumerator SpawnEnemiesInWaves()
    {
        // spawn initial batch of enemies
        for (int i = 0; i < numEnemiesToSpawn; i++)
        {
            SpawnEnemy();
        }

        // spawn enemies in waves, with increasing numbers of enemies per wave
        for (int wave = 0; wave < numWaves; wave++)
        {
            for (int i = 0; i < (enemiesPerWave + wave); i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f); // delay between spawning enemies in a wave
            }
            yield return new WaitForSeconds(delayBetweenWaves); // delay between waves
        }

        // set isSpawning to false so the trigger can be activated again
        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 0, Random.Range(-spawnRange.z, spawnRange.z));
        Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
        enemy.SetActive(true);
    }
}
