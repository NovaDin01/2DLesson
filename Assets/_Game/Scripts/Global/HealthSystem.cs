using UnityEngine;


public class HealthSystem : MonoBehaviour
{
     private float currentHealth;
     private bool isAlive;

    public event System.Action onDeath;
    public void Initialization(float maxHealth)
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0 && isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;
            onDeath?.Invoke();
        }
        
    }
}
