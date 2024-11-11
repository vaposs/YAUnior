using System;
using UnityEngine;

public class DronMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _commandCentre;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private DronLoadUnloadCargo _dronLoadUnloadCargo;

    private int _currentWaypoints = 0;

    private void Update()
    {
        if (_dronLoadUnloadCargo.IsHaveCommand == true)
        {
            MoveToTarget(_dronLoadUnloadCargo.Target);
        }
        else
        {
            if (_dronLoadUnloadCargo.IsHaveResource == true)
            {
                MoveToTarget(_commandCentre);
            }
            else
            {
                FreeMove();
            }
        }
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
        if (collision.gameObject.TryGetComponent(out Resource resource) && _dronLoadUnloadCargo.Target != null)
        {
            if (resource.transform.position == _dronLoadUnloadCargo.Target.transform.position)
            {
                _dronLoadUnloadCargo.LoadCargo(resource);
            }
        }

        if (collision.gameObject.TryGetComponent(out Point point))
        {
            _currentWaypoints = ++_currentWaypoints %  _wayPoints.Length;
        }
    }
}
