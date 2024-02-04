using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletCreater: MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 _direction = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_bullet, transform.position + _direction, Quaternion.identity);

            bullet.transform.up = _direction;
            bullet.velocity = _direction * _speed;

            yield return _delay;
        }
    }
}