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
    public float damageMultiplier = 1.0f; // add a damage multiplier variable

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
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            enemy.GetComponent<EnemyHealth>().SetDamageMultiplier(damageMultiplier); // set the damage multiplier
            enemy.SetActive(true);
        }

        // spawn enemies in waves
        for (int wave = 0; wave < numWaves; wave++)
        {
            yield return new WaitForSeconds(delayBetweenWaves); // delay between waves

            damageMultiplier += 0.2f; // increase the damage multiplier for each wave

            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                enemy.GetComponent<EnemyHealth>().SetDamageMultiplier(damageMultiplier); // set the damage multiplier
                enemy.SetActive(true);
                yield return new WaitForSeconds(0.5f); // delay between spawning enemies in a wave
            }
        }

        // set isSpawning to false so the trigger can be activated again
        isSpawning = false;
    }
}