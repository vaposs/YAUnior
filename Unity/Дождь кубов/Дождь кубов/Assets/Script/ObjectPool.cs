using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private Queue<Cube> _storage;

    private void Awake()
    {
        _storage = new Queue<Cube>();
    }

    public Cube GetCube(Vector3 spawnPosition)
    {
        if (_storage.Count == 0)
        {
            return Instantiate(_cube, spawnPosition, Quaternion.identity);
        }
        else
        {   Cube tempCube;
            tempCube = _storage.Dequeue();
            tempCube.transform.position = spawnPosition;
            tempCube.gameObject.SetActive(true);

            return tempCube;
        }
    }

    public void PutObject(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _storage.Enqueue(cube);
    }
}
