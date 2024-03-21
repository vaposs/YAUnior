using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyBulletPool _enemyBulletPool;

    private Queue<Enemy> _pool;
    private Enemy _tempEnemy;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        float positionY = Random.RandomRange(_minPosition.transform.position.y, _maxPosition.transform.position.y);
        Vector3 spawnPosition =
            new Vector3(
                _minPosition.transform.position.x,
                positionY,
                _minPosition.transform.position.z);

        if (_pool.Count == 0)
        {
            Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemy.Initialize(_enemyBulletPool);
            enemy.transform.parent = _container;
            enemy.Destroyed += PutObject;
            return enemy;
        }
        else
        {
            _tempEnemy = _pool.Dequeue();
            _tempEnemy.transform.position = spawnPosition;
            _tempEnemy.gameObject.SetActive(true);

            return _tempEnemy;
        }
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}