using System;
using UnityEngine;

public class DronMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _cargoTransform;
    [SerializeField] private Transform _commandCentre;
    [SerializeField] private Transform[] _wayPoints;

    private Resource _resource;
    private Transform _target = null;

    private int _currentWaypoints = 0;
    private string _pointTag = "Point";
    private bool _isHaveCommand = false;

    public bool IsHaveResource { get; private set; } = false;

    private void FixedUpdate()
    {
        if (_isHaveCommand == true)
        {
            MoveToTarget(_target);
        }
        else
        {
            if (IsHaveResource == true)
            {
                MoveToTarget(_commandCentre);
            }
            else
            {
                FreeMove();
            }
        }
    }

    private void LoadCargo(Resource resource)
    {
        resource.transform.SetParent(this.transform);
        resource.transform.position = _cargoTransform.position;
        IsHaveResource = true;
        _isHaveCommand = false;
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void FreeMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoints].position, _speed * Time.deltaTime);
        transform.LookAt(_wayPoints[_currentWaypoints]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Resource resource))
        {
            if (_target.transform != null)
            {
                if (resource.transform.position == _target.transform.position)
                {
                    LoadCargo(resource);
                }
            }
        }

        if (collision.gameObject.tag == _pointTag)
        {
            _currentWaypoints++;
            _currentWaypoints %= _wayPoints.Length;
        }
    }

    public void UnloadCargo()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent(out Resource resource))
            {
                _resource = resource;
            }
        }

        _resource.transform.parent = null;
        IsHaveResource = false;
        _resource.ReturnInPool();

    }

    public void GetCommand(Transform target)
    {
        _target = target;
        _isHaveCommand = true;
    }
}
