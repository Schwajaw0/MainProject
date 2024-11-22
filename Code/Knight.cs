using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 2f;
    public float damageAmount = 10f;
    private int health = 2; // Health of the Knight, meaning it can take 2 hits before being destroyed

    private bool isInvincible = false; // Flag to track if the Knight is invincible
    [SerializeField] private float invincibilityDuration = 0.2f; // Time in seconds the Knight is invincible after taking damage

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

        // Check if the Knight collides with an enemy (Skeleton)
        Skeleton skeleton = other.GetComponent<Skeleton>();
        if (skeleton != null && !isInvincible) // Only take damage if not invincible
        {
            TakeDamage(1); // The Knight takes 1 damage when colliding with a Skeleton
            skeleton.TakeDamage(1); // The Skeleton also takes damage
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            Debug.Log($"Knight took damage! Remaining health: {health}");

            if (health <= 0)
            {
                Debug.Log("Knight destroyed!");
                Destroy(gameObject); // Destroy the Knight if health is 0 or below
            }
            else
            {
                StartCoroutine(BecomeTemporarilyInvincible());
            }
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true; // Set the Knight to be invincible
        yield return new WaitForSeconds(invincibilityDuration); // Wait for the invincibility duration
        isInvincible = false; // Remove the invincibility
    }
}
