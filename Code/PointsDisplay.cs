using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointsDisplay : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Reference to the UI Text element

    void Start()
    {
        UpdatePointsDisplay(0); // Initialize points display to start at 0

        // Subscribe to points changes if PlayerPointsManager instance is already available
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged += UpdatePointsDisplay;
            Debug.Log("Subscribed to onPointsChanged event in Start()");
            UpdatePointsDisplay(PlayerPointsManager.Instance.GetPlayerPoints()); // Ensure UI is synced with current points
        }
    }

    void OnEnable()
    {
        // Subscribe to the onPointsChanged event
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged += UpdatePointsDisplay;
            Debug.Log("Subscribed to onPointsChanged event in OnEnable()");
        }
    }

    void OnDisable()
    {
        // Unsubscribe from the onPointsChanged event
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged -= UpdatePointsDisplay;
            Debug.Log("Unsubscribed from onPointsChanged event in OnDisable()");
        }
    }

    // Method to update the points display
    public void UpdatePointsDisplay(int points)
    {
        pointsText.text = "Coins: " + points.ToString();
        Debug.Log($"Updating Points Display: {points}"); // Debug log to confirm UI update
    }
}


