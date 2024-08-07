using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{
    [SerializeField] private Transform _resoursePool;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Resource _resource;

    private Queue<Resource> _poolResource;
    private Resource _tempResource;
    private Vector3 _spawnPosition;
    private float _spawnPositionY = 1f;

    private void Awake()
    {
        _poolResource = new Queue<Resource>();
    }

    private void PutResource(Resource resource)
    {
        resource.gameObject.SetActive(false);
        _poolResource.Enqueue(resource);
        resource.Destroyed -= PutResource;
    }

    public void GetResource()
    {
        _spawnPosition = new Vector3(
                                Random.RandomRange(_minPosition.position.x, _maxPosition.position.x),
                                _spawnPositionY,
                                Random.RandomRange(_minPosition.position.z, _maxPosition.position.z));

        if (_poolResource.Count == 0)
        {
             _tempResource = Instantiate(_resource, _spawnPosition, Quaternion.identity, _resoursePool);
        }
        else
        {
            _tempResource = _poolResource.Dequeue();
            _tempResource.transform.position = _spawnPosition;
            _tempResource.gameObject.SetActive(true);
        }

        _tempResource.Destroyed += PutResource;
    }
}