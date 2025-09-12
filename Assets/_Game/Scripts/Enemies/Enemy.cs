using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDeath += Die;
    }


    protected virtual void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
