using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private AttackSystem _attackSystem;
    private Bullet _bullet;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _attackSystem = GetComponent<AttackSystem>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        bool isAttackButtonPressed = Input.GetButtonDown(GlobalStringVars.ATTACK);
        
        _playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        _attackSystem.Attack(isAttackButtonPressed);
    }
}
