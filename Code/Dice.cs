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

    private void Start()
    {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // If you left click over the dice, then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        finalSide = 0;

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
        Debug.Log($"Dice 1 rolled: {finalSide}");

        // After the current dice finishes rolling, roll the other dice if it exists
        if (otherDice != null)
        {
            Dice otherDiceScript = otherDice.GetComponent<Dice>();
            if (otherDiceScript != null)
            {
                yield return StartCoroutine(otherDiceScript.RollTheDice());

                // Calculate and add points once both dice are rolled
                int totalPoints = finalSide + otherDiceScript.finalSide;
                AddPoints(totalPoints);
            }
        }
    }

    // Method to add points
    private void AddPoints(int points)
    {
        // Assuming you have a points manager to handle player points
        PlayerPointsManager.Instance.AddPoints(points);
    }
}
