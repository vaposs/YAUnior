using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EnemyBulletPool _enemyBulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }

        if(other.TryGetComponent(out EnemyBullet enemyBullet))
        {
            _enemyBulletPool.PutObject(enemyBullet);
        }
    }
}