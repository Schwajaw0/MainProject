using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerPointsManager : MonoBehaviour
{
    public static PlayerPointsManager Instance;

    private int playerPoints;

    
    public event Action<int> onPointsChanged;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
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

       
        onPointsChanged?.Invoke(playerPoints);
    }

    public int GetPlayerPoints()
    {
        return playerPoints;
    }
}
