using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private Animator _animator;
    private float _direction;
    private bool _isGround = true;
    private int _maxSpeed = 5;
    private int _minSpeed = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal") * _speed;
        _rigidbody2D.velocity = new Vector2(_direction, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _isGround = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForse);
            _animator.SetBool("Jump", true);
            _animator.SetFloat("SpeedUpDown", _rigidbody2D.velocity.y);
            FlipX();
        }
        else if(_rigidbody2D.velocity.y < 0)
        {
            _animator.SetFloat("SpeedUpDown", _rigidbody2D.velocity.y);
            FlipX();
        }
        else if(_rigidbody2D.velocity.x > 0)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", _maxSpeed);
            FlipX();

        }
        else if (_rigidbody2D.velocity.x < 0)
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", _maxSpeed);
            FlipX();

        }
        else
        {
            _animator.SetFloat("Speed", _minSpeed);
        }
    }

    private void FlipX()
    {
        if(_direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
        _animator.SetBool("Jump", false);
        _animator.SetFloat("Speed",_rigidbody2D.velocity.x);
        _animator.SetFloat("SpeedUpDown", 0);
    }
}