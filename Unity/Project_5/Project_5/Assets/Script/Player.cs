using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);

    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForse = 5;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private float _direction;

    void Update()
    {
        _direction = Input.GetAxis(Horizontal) * _speed;

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime,0,0);
            _animator.SetFloat(Speed,5);
            FlipX();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((_speed * Time.deltaTime) * -1, 0, 0);
            _animator.SetFloat(Speed, 5);
            FlipX();
        }
        else
        {
            _animator.SetFloat(Speed, 0);
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
}
