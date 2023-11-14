using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Rigidboy Referance")] [SerializeField]
    private Rigidbody _playerRigidbody;

    [Header("Player Transform Referance")] [SerializeField]
    private Transform _playerChildTransfrom;

    [Header("Animation Referance")] [SerializeField]
    private AnimationController _animationController;

    [Header("Joystick Referance")] [SerializeField]
    private DynamicJoystick _dynamicJoystick;

    [Header("Player Speed Value")] [SerializeField]
    private float _moveSpeed;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement()
    {
        _playerRigidbody.velocity = GetNewVelocity();
        // Player Animation 
        _animationController.SetBoolean("Walk", _horizontal != 0 || _vertical != 0);
    }

    private void SetRotation()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            _playerChildTransfrom.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal, _playerRigidbody.velocity.y, _vertical) * (_moveSpeed * Time.fixedDeltaTime);
    }

    private void GetMovementInput()
    {
        _horizontal = _dynamicJoystick.Horizontal;
        _vertical = _dynamicJoystick.Vertical;
    }
}