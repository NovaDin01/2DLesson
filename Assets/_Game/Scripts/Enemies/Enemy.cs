using System;
using UnityEngine;

abstract class Enemy : MonoBehaviour
{
    protected float damage;
    protected float maxHealth;
    protected HealthSystem healthSystem;

    private void Awake()
    {
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
