using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawn : MonoBehaviour
{
    [SerializeField] GameObject KnightPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int knightCost = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        TrySpawnKnight();
    }
    public void TrySpawnKnight()
    {
        
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= knightCost)
        {
            
            PlayerPointsManager.Instance.AddPoints(-knightCost);

            
            Instantiate(KnightPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the knight!");
        }
    }

}
