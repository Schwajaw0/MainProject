using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawn : MonoBehaviour
{
    [SerializeField] GameObject SpearPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int SpearCost = 2;
    
    void Start()
    {

    }

    
    void Update()
    {

    }
    private void OnMouseDown()
    {
        TrySpawnSpear();
    }
    public void TrySpawnSpear()
    {
        
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= SpearCost)
        {
            
            PlayerPointsManager.Instance.AddPoints(-SpearCost);

            
            Instantiate(SpearPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the Spearmen!");
        }
    }
}
