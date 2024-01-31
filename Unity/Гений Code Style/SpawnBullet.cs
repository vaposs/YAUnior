using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delayForShoot;

    private Bullet _bullet;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        while (isWork)
        {
            _bullet.SetDirection(_shootingTarget.position - transform.position).normalized);
            _bullet = Instantiate(_bullet, transform.position + _bullet.BulletDirection, Quaternion.identity);
            _bullet.Fly(_shootingPower);

            yield return new WaitForSeconds(_delayForShoot);
        }
    }
}