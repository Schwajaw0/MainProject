using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyTower : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;

    public Image healthBar;
    public GameObject endGamePanel;
    
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); 
            EndGame();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth; 
        }
    }
    void EndGame()
    {
        
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        
        Time.timeScale = 0f; 
    }
}
