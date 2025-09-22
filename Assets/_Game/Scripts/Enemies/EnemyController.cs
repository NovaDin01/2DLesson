using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Скорость")][SerializeField] private float speed;
    [Header("Аниматор")] [SerializeField] private Animator animator;

    [Header("Границы передвижения")] 
    [SerializeField] private Transform leftBorderTransform;
    [SerializeField] private Transform rightBorderTransform;

    [Header("Время ожидания")] [SerializeField] private float idleTime;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    
    private enum EnemyState {Idle, Walk, Revert}
    
    private EnemyState currentState;
    
    private bool isIdleCoroutineRunning = false;

    private void Start()
    {
        currentState = EnemyState.Walk;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                SetIdleState();
                break;
            case EnemyState.Walk:
                SetWalkState();
                break;
            case EnemyState.Revert:
                SetRevertState();
                break;
        }
    }

    private IEnumerator IdleTimer()
    {
        yield return new WaitForSeconds(idleTime);
        isIdleCoroutineRunning = false;
        currentState = EnemyState.Revert;
    }

    private void SetIdleState()
    {
        SetAnim(true, false);
        ChangeSpeed(true);
        if (!isIdleCoroutineRunning)
        {
            StartCoroutine(IdleTimer());
            isIdleCoroutineRunning = true;
        }
        
    }

    private void SetWalkState()
    {
        SetAnim(false, true);
        ChangeSpeed(false);
    }

    private void SetRevertState()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        speed *= -1;
        currentState = EnemyState.Walk;
    }

    
    private void SetAnim(bool isIdle, bool isRun)
    {
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isRun", isRun);
    }

    private void ChangeSpeed(bool isIdle)
    {
        if (isIdle)
            _rigidbody2D.linearVelocityX = 0;
        else
            _rigidbody2D.linearVelocityX = speed;
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BorderTrigger"))
        {
            currentState = EnemyState.Idle;
        }
    }
}
