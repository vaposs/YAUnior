using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _minSpawnPosition = -5;
    [SerializeField] private int _maxSpawnPosition = 5;
    [SerializeField] private int _spawnPositionY = 10;
    [SerializeField] private Cube _cube;

    private Vector3 _spawnPosition;
    private float _spawnPositionX;
    private float _spawnPositionZ;

    private Queue<Cube> _pool;
    private Cube _tempCube;

    private void Awake()
    {
        _pool = new Queue<Cube>();
    }

    public Cube GetCube()
    {
        _spawnPositionX = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        _spawnPositionZ = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        _spawnPosition = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);


        if (_pool.Count == 0)
        {
            return Instantiate(_cube, _spawnPosition, Quaternion.identity);
        }
        else
        {
            _tempCube = _pool.Dequeue();
            _tempCube.transform.position = _spawnPosition;
            _tempCube.gameObject.SetActive(true);

            return _tempCube;
        }
    }

    public void PutObject(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }
}
