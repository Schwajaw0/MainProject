using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 2f;
    private int health = 1; 

    void Start()
    {

    }

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        playerTower playerTower = other.GetComponent<playerTower>();
        if (playerTower != null)
        {
            
            playerTower.TakeDamage(5); 
            Destroy(gameObject); 
        }

        
        Knight knight = other.GetComponent<Knight>();
        if (knight != null)
        {
            TakeDamage(1); 
            knight.TakeDamage(1); 
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Skeleton took damage! Remaining health: {health}");

        if (health <= 0)
        {
            Debug.Log("Skeleton destroyed!");
            Destroy(gameObject); 
        }
    }
}
