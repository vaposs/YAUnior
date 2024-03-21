using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Enemy : PlayerDestroer
{
    [SerializeField] private float _speed;

    public event Action<Enemy> Destroyed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroyed?.Invoke(this);
        }
    }

    public void Initialize(EnemyBulletPool pool)
    {
        GetComponent<EnemyShoot>().SetBulletPool(pool);
    }
}