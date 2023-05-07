using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSwitchSpawner : MonoBehaviour
{
    public GameObject[] spawners; // An array of spawners to be turned on/off
    public float spawnInterval = 2f; // The interval at which spawners will be turned on/off
    public float excludeChance = 0.2f; // The probability that a spawner will be excluded from being turned on at the start
    private bool isGameRunning = true; // Flag to check if game is running

    private void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            if (Random.value > excludeChance) // Check if spawner should be excluded
            {
                spawners[i].SetActive(true); // Turn on spawner
            }
        }
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomIndex = Random.Range(0, spawners.Length);
            spawners[randomIndex].SetActive(!spawners[randomIndex].activeSelf);
        }
    }
}