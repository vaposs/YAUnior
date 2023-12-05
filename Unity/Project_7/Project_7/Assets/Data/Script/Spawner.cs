using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnTime = 2;
    private float _spawn;

    private void Start()
    {
        _spawn = _spawnTime;
    }

    private void Update()
    {
        _spawn -= Time.deltaTime;

        if (_spawn < 0)
        {
            Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position, Quaternion.identity);
            _spawn = _spawnTime;
        }
    }
}
