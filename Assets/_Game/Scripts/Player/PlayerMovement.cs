using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [Header("Настройки")] 
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask canJumpMask;
    
    [Header("Характеристики игрока")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;

    private float minValue = 0.01f;
    protected HealthSystem healthSystem;
    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDeath += Die;
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, canJumpMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if(isJumpButtonPressed && isGrounded) Jump();
        
        if(Mathf.Abs(direction) > minValue)
        {
            HorizontalMovement(direction);
            _animator.SetBool("isRunning", true);
        }
        
        else _animator.SetBool("isRunning", false);

        if (direction > minValue) _rigidbody2D.transform.rotation = new Quaternion(0, 0, 0, 0);
        else if (direction < -minValue) _rigidbody2D.transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void HorizontalMovement(float direction)
    {
        _rigidbody2D.linearVelocity = new Vector2(_animationCurve.Evaluate(direction), _rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocityX, jumpForce);
    }

    private void TakeDamage()
    {
        
    }

    private void Die()
    {
        SceneController.Instance.ReloadScene();
    }
    
}
