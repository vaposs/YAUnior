using UnityEngine;

public class MovePointChild : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;

    private Transform[] _pointsChild;
    private int _currentPoint;

    private void Start()
    {
        _pointsChild = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
        {
            _pointsChild[i] = _points.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform chosePoint = _pointsChild[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, chosePoint.position, _speed * Time.deltaTime);

        if (transform.position == chosePoint.position)
        {
            MoveToPoint();
        }
    }

    private Vector3 MoveToPoint()
    {
        _currentPoint++;

        if (_currentPoint == _pointsChild.Length)
        {
            _currentPoint = 0;
        }

        Vector3 currentPointPosition = _pointsChild[_currentPoint].transform.position;
        transform.forward = currentPointPosition - transform.position;

        return currentPointPosition;
    }
}