using UnityEngine;

public class MoverToChildrenPoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;

    private Transform[] _waypoints;
    private int _currentPoint;

    private void Start()
    {
        _waypoints = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
        {
            _waypoints[i] = _points.GetChild(i).transform;
        }
    }

    private void Update()
    {
        Transform chosePoint = _waypoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, chosePoint.position, _speed * Time.deltaTime);

        if (transform.position == chosePoint.position)
        {
            MoveToPoint();
        }
    }

    private Vector3 MoveToPoint()
    {
        _currentPoint++;

        if (_currentPoint == _waypoints.Length)
        {
            _currentPoint = 0;
        }

        Vector3 currentPointPosition = _waypoints[_currentPoint].transform.position;
        transform.forward = currentPointPosition - transform.position;

        return currentPointPosition;
    }
}