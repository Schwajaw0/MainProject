using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Reference to another dice GameObject
    public GameObject otherDice;

    // Variable to store final value after the roll
    private int finalSide;

    // Reference to EnemyWaveSpawner to start a wave after rolling the dice
    [SerializeField] private GameObject EnemyWaves;

    private EnemyWaves waveSpawner;

    // To prevent re-rolling while the dice are still rolling
    private static bool isRolling = false;

    private void Start()
    {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");

        // Get the EnemyWaveSpawner script from the assigned GameObject
        if (EnemyWaves != null)
        {
            waveSpawner = EnemyWaves.GetComponent<EnemyWaves>();
        }
    }

    // If you left click over the dice, then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        if (!isRolling) // Ensure dice are not rolled again until the current roll finishes
        {
            StartCoroutine(RollBothDice());
        }
    }

    // Coroutine to roll both dice
    private IEnumerator RollBothDice()
    {
        isRolling = true; // Prevent re-rolling until this roll finishes

        // Roll the current dice
        yield return StartCoroutine(RollTheDice());

        // Roll the other dice if it exists
        int totalPoints = finalSide; // Start with the value from this dice

        if (otherDice != null)
        {
            Dice otherDiceScript = otherDice.GetComponent<Dice>();
            if (otherDiceScript != null)
            {
                yield return StartCoroutine(otherDiceScript.RollTheDice());
                totalPoints += otherDiceScript.finalSide; // Add value from the other dice
            }
        }

        // Show final points value in Console
        Debug.Log($"Total points from both dice: {totalPoints}");

        // Add points to the player's score
        AddPoints(totalPoints);

        // Start the next wave after rolling both dice and adding points
        if (waveSpawner != null)
        {
            waveSpawner.StartNextWave();
        }

        isRolling = false; // Allow rolling again after this roll finishes
    }

    // Coroutine that rolls a single dice
    public IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        // Loop to switch dice sides randomly before final side appears (20 iterations here)
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        // Assign the final side
        finalSide = randomDiceSide + 1;

        // Show final dice value in Console
        Debug.Log($"Dice rolled: {finalSide}");
    }

    // Method to add points
    private void AddPoints(int points)
    {
        // Assuming you have a points manager to handle player points
        PlayerPointsManager.Instance.AddPoints(points);
    }
}
