using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _delay;
    private EnemyBulletPool _pool;
    private Coroutine _startCorotine;

    private void OnEnable()
    {
        _startCorotine = StartCoroutine(Shooting(_delay));
    }

    private void OnDisable()
    {
        if (_startCorotine != null)
        {
            StopCoroutine(_startCorotine);
        }
    }
    
    private IEnumerator Shooting(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return null;

        while (enabled)
        {
            _pool.GetObject(transform);
            yield return wait;
        }
    }

    public void SetBulletPool(EnemyBulletPool enemyBulletPool)
    {
        _pool = enemyBulletPool;
    }
}