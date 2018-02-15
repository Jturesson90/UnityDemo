using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class Knight : MonoBehaviour
{

    public float Speed = 5f;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private int _animatorSpeedKey;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animatorSpeedKey = Animator.StringToHash("speed");
    }


    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Move(horizontalInput);
        Animating();
        Turning();
    }

    private void Turning()
    {
        if (_rigidBody.velocity.x < 0)
        {
            var newScale = transform.localScale;
            newScale.x = -Mathf.Abs(newScale.x);
            transform.localScale = newScale;

        }
        else if (_rigidBody.velocity.x > 0)
        {
            var newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
    }

    private void Animating()
    {
        _animator.SetFloat(_animatorSpeedKey, Mathf.Abs(_rigidBody.velocity.x));
    }

    private void Move(float horizontalInput)
    {
        _rigidBody.velocity = new Vector3(horizontalInput * Speed, _rigidBody.velocity.y);
    }
}
