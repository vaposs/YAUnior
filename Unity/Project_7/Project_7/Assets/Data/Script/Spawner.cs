using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Gem[] _prefabs;
    [SerializeField] private float _spawnTime = 2;
    private float _currentSpawn;

    private void Start()
    {
        _currentSpawn = _spawnTime;
    }

    private void Update()
    {
        _currentSpawn -= Time.deltaTime;

        if (_currentSpawn < 0)
        {
            Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position, Quaternion.identity);
            _currentSpawn = _spawnTime;
        }
    }
}