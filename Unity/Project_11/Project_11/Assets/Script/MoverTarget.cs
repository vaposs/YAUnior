using UnityEngine;

public class MoverTarget : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentPoints = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentPoints].position, _speed);

        if (transform.position == _wayPoints[_currentPoints].position)
        {
            _currentPoints = (_currentPoints + 1) % _wayPoints.Length;
        }
    }
}