using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{
    [SerializeField] private Transform _resoursePool;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Resource _resource;

    private Queue<Resource> _poolActiveResource;
    private Queue<Resource> _poolDeactiveResource;
    private Resource _tempResource;
    private Vector3 _spawnPosition;
    private float _spawnPositionY = 1f;

    private void Awake()
    {
        _poolActiveResource = new Queue<Resource>();
        _poolDeactiveResource = new Queue<Resource>();
    }

    private void OnEnable()
    {
        Resource.Destroyed += PutResource;
    }

    private void OnDisable()
    {
        Resource.Destroyed -= PutResource;
    }


    public void GetResource()
    {
        _spawnPosition = new Vector3(
                                Random.RandomRange(_minPosition.position.x, _maxPosition.position.x),
                                _spawnPositionY,
                                Random.RandomRange(_minPosition.position.z, _maxPosition.position.z));

        if (_poolDeactiveResource.Count == 0)
        {
            Resource resource = Instantiate(_resource, _spawnPosition, Quaternion.identity, _resoursePool);

            _poolActiveResource.Enqueue(resource);
        }
        else
        {
            _tempResource = _poolDeactiveResource.Dequeue();
            _tempResource.transform.position = _spawnPosition;
            _tempResource.gameObject.SetActive(true);
            _poolActiveResource.Enqueue(_tempResource);
        }
    }

    public Resource GetPosition()
    {
        return _poolActiveResource.Dequeue();
    }

    public int CheckCounPool()
    {
        return _poolActiveResource.Count;
    }

    public void PutResource(Resource resource)
    {
        resource.gameObject.SetActive(false);
        _poolDeactiveResource.Enqueue(resource);

    }
}
