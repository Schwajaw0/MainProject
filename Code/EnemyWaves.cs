using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;  // Enemy prefab to spawn
    [SerializeField] Transform spawnPoint;    // The spawn point where enemies will appear
    [SerializeField] int enemiesPerWave = 5;  // Initial number of enemies per wave
    [SerializeField] float spawnInterval = 1f; // Time interval between spawning individual enemies in a wave
    [SerializeField] float delayBeforeWaveStarts = 3f; // Delay before a wave starts after rolling the dice

    private int currentWave = 0;              // Keeps track of the current wave

    // Method to be called when the player rolls the dice
    public void StartNextWave()
    {
        currentWave++;
        Debug.Log("Wave " + currentWave + " will start after a delay of " + delayBeforeWaveStarts + " seconds.");
        StartCoroutine(StartWaveAfterDelay());
    }

    IEnumerator StartWaveAfterDelay()
    {
        // Wait for the specified delay before starting the wave
        yield return new WaitForSeconds(delayBeforeWaveStarts);

        Debug.Log("Wave " + currentWave + " starting!");

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval); // Wait between each enemy spawn in the wave
        }

        // Increase the number of enemies for the next wave by 2
        enemiesPerWave += 2;
        Debug.Log("Next wave will contain " + enemiesPerWave + " enemies.");
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy at the spawn point's position and rotation
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
