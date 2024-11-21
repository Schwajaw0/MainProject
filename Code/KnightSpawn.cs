using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawn : MonoBehaviour
{
    [SerializeField] GameObject KnightPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int knightCost = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        TrySpawnKnight();
    }
    public void TrySpawnKnight()
    {
        // Check if PlayerPointsManager exists and if the player has enough points
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= knightCost)
        {
            // Deduct points for spawning the knight
            PlayerPointsManager.Instance.AddPoints(-knightCost);

            // Spawn the knight at the spawn point
            Instantiate(KnightPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the knight!");
        }
    }

}
