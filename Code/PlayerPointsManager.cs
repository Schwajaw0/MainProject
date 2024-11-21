using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerPointsManager : MonoBehaviour
{
    public static PlayerPointsManager Instance;

    private int playerPoints;

    // Declare an event to notify listeners when points change
    public event Action<int> onPointsChanged;

    void Awake()
    {
        // Set up singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the PlayerPointsManager persists
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        playerPoints += points;
        Debug.Log($"Points Added: {points}. Total Points: {playerPoints}");

        // Trigger the onPointsChanged event to update UI
        onPointsChanged?.Invoke(playerPoints);
    }

    public int GetPlayerPoints()
    {
        return playerPoints;
    }
}
