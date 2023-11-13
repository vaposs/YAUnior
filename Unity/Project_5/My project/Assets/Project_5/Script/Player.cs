using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForse = 5;
    [SerializeField] private bool _isGround;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float _direction;
    private int _maxSpeed = 5;
    private int _minSpeed = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxis("Horizontal") * _speed;

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime,0,0);
            _animator.SetFloat("speed",_maxSpeed);
            FlipX();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((_speed * Time.deltaTime) * -1, 0, 0);
            _animator.SetFloat("speed", _maxSpeed);
            FlipX();
        }
        else
        {
            _animator.SetFloat("speed", _minSpeed);
        }
    }

    private void FlipX()
    {
        if (_direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        _isGround = true;
        _animator.SetBool("isGroung", true);
    }
}
