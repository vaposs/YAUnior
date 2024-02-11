using UnityEngine;

public class EnemyMover : MonoBehaviour
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
        if (_moveBack)
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
            if (_moveBack)
            {
                _moveBack = false;
            }
            else
            {
                _moveBack = true;
            }

            FlipX();
        }
    }

    private void FlipX()
    {
        if (_moveBack == false)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }
}
