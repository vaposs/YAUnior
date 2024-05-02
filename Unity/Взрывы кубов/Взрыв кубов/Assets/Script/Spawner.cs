using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private CubeTwoPointZero _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, _spawnPosition);
    }
}
