using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletPrefab;
    private Vector3 _bulletDirection;
    public Vector3 BulletDirection { get { return _bulletDirection; } private set { } }

    private void Start()
    {
        _bulletPrefab = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        _bulletDirection = direction;
    }

    public void Fly(float shootingPower)
    {
        _bulletPrefab.transform.up = _bulletDirection;
        _bulletPrefab.velocity = _bulletDirection * shootingPower;
    }
}