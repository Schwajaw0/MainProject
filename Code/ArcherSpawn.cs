using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSpawn : MonoBehaviour
{
    [SerializeField] GameObject ArcherPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int ArcherCost = 1;
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
        TrySpawnArcher();
    }
    public void TrySpawnArcher()
    {
        // Check if PlayerPointsManager exists and if the player has enough points
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= ArcherCost)
        {
            // Deduct points for spawning the knight
            PlayerPointsManager.Instance.AddPoints(-ArcherCost);

            // Spawn the knight at the spawn point
            Instantiate(ArcherPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the Archer!");
        }
    }
}
