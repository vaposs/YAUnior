using System;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Bullet> onHit;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            onHit?.Invoke(this);
        }
    }
}