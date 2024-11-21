using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyTower : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health
    private float currentHealth;

    public Image healthBar;
    public GameObject endGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the tower when health reaches zero
            EndGame();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth; // Update health bar fill
        }
    }
    void EndGame()
    {
        // Show the end game panel
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        // Stop the game or freeze player input if needed
        Time.timeScale = 0f; // Freezes the game
    }
}
