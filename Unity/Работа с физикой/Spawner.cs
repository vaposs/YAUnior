using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private GameObject _prefab;
    private float _timeSpawnStart;

    void Start()
    {
        _timeSpawnStart = _timeSpawn;
    }

    void Update()
    {
        _timeSpawn -= Time.deltaTime;

        if(_timeSpawn < 0)
        {
            Instantiate(_prefab,new Vector3(_spawnPosition.position.x, _spawnPosition.position.y, _spawnPosition.position.z), Quaternion.identity);

            _timeSpawn = _timeSpawnStart;
        }
    }
}
