using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    public int CurrentHealth { get; private set; }
    private bool isAlive;

    public event System.Action onDeath;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(CurrentHealth, 0);

        if (CurrentHealth <= 0 && isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        onDeath?.Invoke();
    }
}