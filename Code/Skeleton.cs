using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 2f;
    private int health = 1; // Health of the enemy, 1 means it can take 1 hit

    void Start()
    {

    }

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with a troop (Knight)
        Knight knight = other.GetComponent<Knight>();
        if (knight != null)
        {
            TakeDamage(1); // Enemy takes 1 damage when colliding with a Knight
            knight.TakeDamage(1); // The Knight also takes damage
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy if health is 0 or below
        }
    }
}
