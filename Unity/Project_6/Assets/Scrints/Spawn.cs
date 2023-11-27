using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private float _spawnTime = 3;
    [SerializeField] private GameObject _prefab;
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
        int indexSpawn = Random.Range(0, _gameObjects.Length);
        Instantiate(_prefab, _gameObjects[indexSpawn].transform.position, _gameObjects[indexSpawn].transform.rotation);
    }
}
