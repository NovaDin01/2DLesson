using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected HealthSystem healthSystem;
    private ScoreHolder scoreHolder;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDeath += Die;
        
        scoreHolder = GetComponent<ScoreHolder>();
    }


    protected virtual void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
    }

    protected virtual void Die()
    {
        scoreHolder.GetScore();
        Destroy(gameObject);
    }
}
