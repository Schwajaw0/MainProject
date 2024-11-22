using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;  
    [SerializeField] Transform spawnPoint;    
    [SerializeField] int enemiesPerWave = 5;  
    [SerializeField] float spawnInterval = 1f; 
    [SerializeField] float delayBeforeWaveStarts = 3f; 

    private int currentWave = 0;              

    
    public void StartNextWave()
    {
        currentWave++;
        Debug.Log("Wave " + currentWave + " will start after a delay of " + delayBeforeWaveStarts + " seconds.");
        StartCoroutine(StartWaveAfterDelay());
    }

    IEnumerator StartWaveAfterDelay()
    {
        
        yield return new WaitForSeconds(delayBeforeWaveStarts);

        Debug.Log("Wave " + currentWave + " starting!");

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval); 
        }

        
        enemiesPerWave += 2;
        Debug.Log("Next wave will contain " + enemiesPerWave + " enemies.");
    }

    void SpawnEnemy()
    {
        
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
