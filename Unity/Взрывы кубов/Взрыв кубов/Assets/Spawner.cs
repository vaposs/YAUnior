using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Cube _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, _spawnPosition);
    }
}
