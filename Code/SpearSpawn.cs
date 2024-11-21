using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawn : MonoBehaviour
{
    [SerializeField] GameObject SpearPrefab;
    [SerializeField] GameObject Spawner;
    [SerializeField] int SpearCost = 2;
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
        TrySpawnSpear();
    }
    public void TrySpawnSpear()
    {
        // Check if PlayerPointsManager exists and if the player has enough points
        if (PlayerPointsManager.Instance != null && PlayerPointsManager.Instance.GetPlayerPoints() >= SpearCost)
        {
            // Deduct points for spawning the knight
            PlayerPointsManager.Instance.AddPoints(-SpearCost);

            // Spawn the knight at the spawn point
            Instantiate(SpearPrefab, Spawner.transform.position, Spawner.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough points to spawn the Spearmen!");
        }
    }
}
