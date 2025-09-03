using System;
using System.Collections;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float damage;
    private GameObject target;

    public void Attack(bool isAttackButtonPressed)
    {
        if (isAttackButtonPressed) StartCoroutine(AttackMoment());
    }

    private void CreateBullet()
    {
        // Необходимо написать логику создания пули, которая при касании проверяет наличие HealthSystem и делает TakeDamage
    }

    private IEnumerator AttackMoment()
    {
        _animator.SetBool("isAttack", true);
        
        yield return new WaitForSeconds(0.2f);
        
        CreateBullet(); 
        
        if (target != null) // убрать
        {
            Debug.Log(target);
            var health = target.GetComponent<HealthSystem>();
            if (health != null) health.TakeDamage(damage);
        }
        _animator.SetBool("isAttack", false);
    }

}
