using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] private Transform _sphereTransform;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed = 0.5f;
    private bool _moveBack = false;

    private void Start()
    {
        _sphereTransform.position = _startPoint.position;
    }

    private void Update()
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
        _sphereTransform.position = Vector3.MoveTowards(_sphereTransform.position, target.position, _speed);

        if (_sphereTransform.position == target.position)
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