using UnityEngine;

public class Sphere_move : MonoBehaviour
{

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed = 0.5f;
    private bool _moveBack = false;

    void Start()
    {
        transform.position = _startPoint.position;
    }
    void Update()
    {
        if (_moveBack)
        {
            Move(_endPoint);
        }
        else
        {
            Move(_startPoint);
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed);

        if (transform.position == target.position)
        {
            if (_moveBack == false)
            {
                _moveBack = true;
            }
            else
            {
                _moveBack = false;
            }
        }
    }
}