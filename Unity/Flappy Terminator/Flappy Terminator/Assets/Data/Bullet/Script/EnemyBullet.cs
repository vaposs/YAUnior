using UnityEditor;
using UnityEngine;

public class EnemyBullet : PlayerDestroer
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}