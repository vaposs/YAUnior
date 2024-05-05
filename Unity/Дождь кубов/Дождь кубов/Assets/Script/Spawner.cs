using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minSpawnPosition = -5;
    [SerializeField] private int _maxSpawnPosition = 5;
    [SerializeField] private int _spawnPositionY = 10;
    [SerializeField] private Cube _cube;
    [SerializeField] float _delay;

    private WaitForSeconds _wait;
    private Vector3 _spawnPosition;
    private float _spawnPositionX;
    private float _spawnPositionZ;

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

            Instantiate(_cube, _spawnPosition, Quaternion.identity);
            yield return _wait;
        }
    }
}
