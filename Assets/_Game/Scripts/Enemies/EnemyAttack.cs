using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Урон: ")] [SerializeField] private int damage;
    [Header("Скорость атаки: ")] [SerializeField] private float attackCooldown;
    private HealthSystem player;
    
    private bool canAttack = true;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("555");
            player = other.GetComponent<HealthSystem>();
            StartCoroutine(AttackCoroutine(player));
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            player = null;
    }

    private IEnumerator AttackCoroutine(HealthSystem playerHealth)
    {
        if (player != null && canAttack)
        {
            canAttack = false;
            playerHealth.TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; 
    }
}
