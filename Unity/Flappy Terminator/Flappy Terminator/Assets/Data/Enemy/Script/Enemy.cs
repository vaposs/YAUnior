using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Enemy> onDestroyed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            onDestroyed?.Invoke(this);
        }
    }

    public void Initialize(EnemyBulletPool pool)
    {
        GetComponent<EnemyShoot>().SetBulletPool(pool);
    }
}