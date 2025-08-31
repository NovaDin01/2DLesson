using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isAlive;

    private void Awake()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void Die()
    {
        if(currentHealth <= 0) isAlive = false;
    }
}
