using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointEnd;
    [SerializeField] private float _speed;

    private bool _moveBack = false;

    private void Start()
    {
        transform.position = _pointStart.position;
    }

    private void Update()
    {
        if(_moveBack)
        {
            Move(_pointEnd);
        }
        else
        {
            Move(_pointStart);
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed);

        if (transform.position == target.position)
        {
            if(_moveBack == false)
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
