using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;

    private string _horizontalSpeed = "HorizontalSpeed";
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float _inputPlayer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _inputPlayer = Input.GetAxis(Horizontal);

        _rigidbody2D.velocity = new Vector2(_inputPlayer * _speed, _rigidbody2D.velocity.y);
        _animator.SetFloat(_horizontalSpeed, Mathf.Abs(_inputPlayer));
        FlipX();
    }

    private void FlipX()
    {
        if (_inputPlayer > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (_inputPlayer < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}