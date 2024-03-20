using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _pool.PutObject(bullet);
        }
    }
}