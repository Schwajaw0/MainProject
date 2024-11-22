using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointsDisplay : MonoBehaviour
{
    public TextMeshProUGUI pointsText; 

    void Start()
    {
        UpdatePointsDisplay(0); 

        
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged += UpdatePointsDisplay;
            Debug.Log("Subscribed to onPointsChanged event in Start()");
            UpdatePointsDisplay(PlayerPointsManager.Instance.GetPlayerPoints()); 
        }
    }

    void OnEnable()
    {
        
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged += UpdatePointsDisplay;
            Debug.Log("Subscribed to onPointsChanged event in OnEnable()");
        }
    }

    void OnDisable()
    {
        
        if (PlayerPointsManager.Instance != null)
        {
            PlayerPointsManager.Instance.onPointsChanged -= UpdatePointsDisplay;
            Debug.Log("Unsubscribed from onPointsChanged event in OnDisable()");
        }
    }

    
    public void UpdatePointsDisplay(int points)
    {
        pointsText.text = "Coins: " + points.ToString();
        Debug.Log($"Updating Points Display: {points}"); 
    }
}


