using UnityEngine;

public class DronMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Cargo _cargo;

    private Transform _target;
    private Transform _commandCentre;
    private Transform[] _wayPoints;
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

    public void TakeWaypoints(Transform[] wayPoints)
    {
        _wayPoints = wayPoints;
    }

    public void UnloadCargo()
    {
        _isHaveResource = false;
        _cargo.gameObject.SetActive(false);
    }

    public void LoadCargo()
    {
        _isHaveCommand = false;
        _isHaveResource = true;
        _cargo.gameObject.SetActive(true);
    }

    public void TakeCommandCentrePosition(Transform commandCentre)
    {
        _commandCentre = commandCentre;
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
}
