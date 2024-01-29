using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;

    private Transform[] _childPoints;
    private Transform _point;
    private int _currentPoint = 0;
    private Vector3 _currentPointPosition;

    private void Start()
    {
        _childPoints = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
        {
            _childPoints[i] = _points.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        _point = _childPoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

        if (transform.position == _point.position)
        {
            GoNextPoint();
        }
    }

    private Vector3 GoNextPoint()
    {
        _currentPoint++;

        if (_currentPoint == _childPoints.Length)
        {
            _currentPoint = 0;
        }

        _currentPointPosition = _childPoints[_currentPoint].transform.position;
        transform.forward = _currentPointPosition - transform.position;

        return _currentPointPosition;
    }
}