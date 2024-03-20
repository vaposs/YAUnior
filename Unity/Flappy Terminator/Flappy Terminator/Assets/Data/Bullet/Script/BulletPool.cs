using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _containerBullet;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _spawn;

    private Queue<Bullet> _poolBullet;
    private Bullet _tempBullet;

    private void OnEnable()
    {
        _bullet.onHit += PutObject;
    }

    private void OnDisable()
    {
        _bullet.onHit -= PutObject;
    }

    private void Awake()
    {
        _poolBullet = new Queue<Bullet>();
    }

    public Bullet GetObject()
    {
        if (_poolBullet.Count == 0)
        {
            Bullet bullet = Instantiate(_bullet, _spawn.position, _spawn.rotation);
            bullet.transform.parent = _containerBullet;
            return bullet;
        }
        else
        {
            _tempBullet = _poolBullet.Dequeue();
            _tempBullet.transform.position = _spawn.position;
            _tempBullet.transform.rotation = _spawn.rotation;
            _tempBullet.gameObject.SetActive(true);

            return _tempBullet;
        }
    }

    public void PutObject(Bullet bullet)
    {
        _poolBullet.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}