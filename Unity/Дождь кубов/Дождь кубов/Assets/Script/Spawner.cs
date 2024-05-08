using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] ObjectPool _objectPool;
    [SerializeField] private int _minSpawnPosition = -5;
    [SerializeField] private int _maxSpawnPosition = 5;
    [SerializeField] private int _spawnPositionY = 10;

    private Vector3 _spawnPosition;
    private float _spawnPositionX;
    private float _spawnPositionZ;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _spawnPositionX = Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPositionZ = Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPosition = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);

            _objectPool.GetCube(_spawnPosition);
            yield return _wait;
        }
    }
}