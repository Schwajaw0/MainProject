using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerTower : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;

    public Image healthBar;
    
    
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
           
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth; 
        }
    }
   
}
