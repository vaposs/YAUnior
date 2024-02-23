using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private int _forse;

    private string _groundTag = "Ground";
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float _direction;
    private bool _isGround = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw(Horizontal) * _speed;
        _rigidbody2D.velocity = new Vector2(_direction, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _isGround = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForse);
            FlipX();
        }
        else if(_rigidbody2D.velocity.y < 0)
        {
            FlipX();
        }
        else if(_rigidbody2D.velocity.x > 0)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            FlipX();

        }
        else if (_rigidbody2D.velocity.x < 0)
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            FlipX();

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == _groundTag)
        {
            _isGround = true;
        }
    }

    public void AddForse()
    {
        _rigidbody2D.AddForce(transform.up * _forse);
    }
}