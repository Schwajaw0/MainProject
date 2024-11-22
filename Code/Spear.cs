using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed = 2f;
    public float damageAmount = 20f;
    private int health = 3; 

    private bool isInvincible = false; 
    [SerializeField] private float invincibilityDuration = 0.2f; 

    void Start()
    {

    }

    void Update()
    {
        // Move the troop to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the enemy tower
        enemyTower enemyTower = other.GetComponent<enemyTower>();
        if (enemyTower != null)
        {
            enemyTower.TakeDamage(damageAmount);
        }

       
        Skeleton skeleton = other.GetComponent<Skeleton>();
        if (skeleton != null && !isInvincible) // Only take damage if not invincible
        {
            TakeDamage(1); 
            skeleton.TakeDamage(1); // The Skeleton also takes damage
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            Debug.Log($"Spearman took damage! Remaining health: {health}");

            if (health <= 0)
            {
                Debug.Log("SpearMan destroyed!");
                Destroy(gameObject); 
            }
            else
            {
                StartCoroutine(BecomeTemporarilyInvincible());
            }
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true; 
        yield return new WaitForSeconds(invincibilityDuration); // Wait for the invincibility duration
        isInvincible = false; // Remove the invincibility
    }
}
