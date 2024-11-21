using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 2f;
    public float damageAmount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the enemy tower
        enemyTower enemyTower = other.GetComponent<enemyTower>();
        if (enemyTower != null)
        {
           enemyTower.TakeDamage(damageAmount);
        }
   }
}