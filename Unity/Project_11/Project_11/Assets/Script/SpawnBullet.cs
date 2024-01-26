using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _spawnTime = 3;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private TrackTarget _trackTarget;

    private float _shootTime;

    private void Start()
    {
        _shootTime = _spawnTime;
    }

    private void Update()
    {
        _shootTime -= Time.deltaTime;

        if (_shootTime < 0)
        {
            _shootTime = _spawnTime;
            Shoot();
        }
    }

    private void Shoot()
    {
       Bullet bullet =  Instantiate(_bullet, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
       bullet.SetTarget(_trackTarget.TakePositionTarget());
    }
}