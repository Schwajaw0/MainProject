using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSpawn : MonoBehaviour
{
    [SerializeField] GameObject ArcherPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int ArcherCost = 1;
    
    void Start()
    {

    }

    
    void Update()
    {

    }
    private void OnMouseDown()
    {
        TrySpawnArcher();
    }
    public void TrySpawnArcher()
    {
        
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= ArcherCost)
        {
            
            PlayerPointsManager.Instance.AddPoints(-ArcherCost);

            
            Instantiate(ArcherPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the Archer!");
        }
    }
}
