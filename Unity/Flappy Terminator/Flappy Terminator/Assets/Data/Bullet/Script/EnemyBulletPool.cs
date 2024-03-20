using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private EnemyBullet _enemyBullet;

    private Queue<EnemyBullet> _pool = new Queue<EnemyBullet>();
    private EnemyBullet _tempEnemyBullet;

    public EnemyBullet GetObject(Transform spawnBullet)
    {
        if (_pool.Count == 0)
        {
            var bullet = Instantiate(_enemyBullet, spawnBullet.transform.position, Quaternion.identity);
            bullet.transform.parent = gameObject.transform;
            return bullet;
        }
        else
        {
            _tempEnemyBullet = _pool.Dequeue();
            _tempEnemyBullet.transform.position = spawnBullet.transform.position;
            _tempEnemyBullet.gameObject.SetActive(true);

            return _tempEnemyBullet;
        }
    }

    public void PutObject(EnemyBullet enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}