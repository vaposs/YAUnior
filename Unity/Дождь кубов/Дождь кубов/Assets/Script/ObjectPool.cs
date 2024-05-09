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

    private void OnEnable()
    {
        Cube.ReturnPool += PutObject;
    }

    private void Disable()
    {
        Cube.ReturnPool -= PutObject;
    }

    public Cube GetCube()
    {
        if (_storage.Count == 0)
        {
            return Instantiate(_cube, transform.position, Quaternion.identity);
        }
        else
        {
            Cube tempCube = _storage.Dequeue();
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
