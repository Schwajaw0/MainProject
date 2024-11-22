using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 2f;
    public float damageAmount = 10f;
    private int health = 2; 

    private bool isInvincible = false; 
    [SerializeField] private float invincibilityDuration = 0.2f; 

    void Start()
    {

    }

    void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        enemyTower enemyTower = other.GetComponent<enemyTower>();
        if (enemyTower != null)
        {
            enemyTower.TakeDamage(damageAmount);
        }

        
        Skeleton skeleton = other.GetComponent<Skeleton>();
        if (skeleton != null && !isInvincible) 
        {
            TakeDamage(1); 
            skeleton.TakeDamage(1); 
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
        yield return new WaitForSeconds(invincibilityDuration); 
        isInvincible = false; 
    }
}
