using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float maxHealth;
    protected HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Initialization(maxHealth);
        healthSystem.onDeath += Die;
    }


    protected virtual void TakeDamage(float damage)
    {
        healthSystem.TakeDamage(damage);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
