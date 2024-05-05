using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Cube _cube;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_cube, _spawnPosition.position, Quaternion.identity);
        }
    }
}
