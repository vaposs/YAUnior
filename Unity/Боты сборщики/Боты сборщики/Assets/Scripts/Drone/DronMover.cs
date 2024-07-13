using System;
using UnityEngine;

public class DronMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _cargoTransform;
    [SerializeField] private Transform _commandCentre;
    [SerializeField] private Transform[] _wayPoints;

    private Resource _resource;
    private Transform _target;

    private int _currentWaypoints = 0;
    private bool _isHaveResource = false;
    private bool _isHaveCommand;

    private void Update()
    {
        if(_isHaveCommand == true)
        {
            MoveResource();
        }
        else
        {
            if (_isHaveResource == true)
            {
                MoveToBase();
            }
            else
            {
                FreeMove();
            }
        }
    }

    private void MoveResource()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void MoveToBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _commandCentre.position, _speed * Time.deltaTime);
        transform.LookAt(_commandCentre);
    }

    private void FreeMove()
    {
        if (transform.position == _wayPoints[_currentWaypoints].position)
        {
            _currentWaypoints = (_currentWaypoints + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoints].position, _speed * Time.deltaTime);
        transform.LookAt(_wayPoints[_currentWaypoints]);
    }

    public void UnloadCargo()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.TryGetComponent(out Resource resource))
            {
                _resource = resource;
            }
        }

        _isHaveResource = false;
        _resource.transform.SetParent(_cargoTransform);
    }

    public Transform LoadCargo()
    {
        _isHaveCommand = false;
        _isHaveResource = true;
        return _cargoTransform;
    }

    public bool IsHaveResourse()
    {
        return _isHaveResource;
    }

    public void TakeCommand(Transform target)
    {
        _target = target;
        _isHaveCommand = true;
    }

    public Transform TakeTargetPosition()
    {
        return _target;
    }
}
