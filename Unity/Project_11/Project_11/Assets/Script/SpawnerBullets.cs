using System.Collections;
using UnityEngine;

public class SpawnerBullets : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _spawnTime = 3;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private TrackerTarget _trackerTarget;

    private bool _shooting = true;

    private void Start()
    {
        StartCoroutine(Caller(_spawnTime));
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bullet, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
        bullet.SetTarget(_trackerTarget.TakePositionTarget());
    }

    private IEnumerator Caller(float delay)
    {
        while (_shooting)
        {
            Shoot();
            yield return new WaitForSeconds(delay);
        }
    }
}