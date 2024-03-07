using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _timeToDie;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteDie;

    private Bullet _bullet;
    private float _timeDie = 0.25f;

    private void Start()
    {
        Destroy(gameObject, _timeToDie);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out _bullet))
        {
            Destroy(collision.gameObject);
            _spriteRenderer.sprite = _spriteDie;
            Destroy(gameObject, _timeDie);
        }
    }
}