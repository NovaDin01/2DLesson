using System.Collections;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [Header("Настройки атаки")]
    [SerializeField] private Animator _animator;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private float attackCooldown = 0.2f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    
    private bool canAttack = true;
    

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }

    public void Attack(bool isAttackButtonPressed)
    {
        if (isAttackButtonPressed && canAttack)
            StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        canAttack = false;
        _animator.SetBool("isAttack", true);

        yield return new WaitForSeconds(attackCooldown);

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            HealthSystem health = hit.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log($"Нанесено {damage} урона -> {hit.name}");
            }
        }
        
        _animator.SetBool("isAttack", false);
        
        yield return new WaitForSeconds(attackCooldown * 0.5f);
        canAttack = true;
    }
}