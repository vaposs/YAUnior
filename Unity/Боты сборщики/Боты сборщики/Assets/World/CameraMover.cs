using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private KeyCode _left = KeyCode.A;
    private KeyCode _right = KeyCode.D;
    private KeyCode _up = KeyCode.W;
    private KeyCode _down = KeyCode.S;

    private float _heightPosition;
    private float _wightPosition;
    private float _height = 145;
    private float _minHeightPosition = -176f;
    private float _maxHeightPosition = 176f;
    private float _minWightPosition = 260f;
    private float _maxWightPosition = 470f;

    public void Update()
    {
        if (Input.GetKey(_left))
        {
            _heightPosition = -1;
        }
        else if (Input.GetKey(_right))
        {
            _heightPosition = 1;
        }
        else
        {
            _heightPosition = 0;
        }

        if (Input.GetKey(_up))
        {
            _wightPosition = 1;
        }
        else if (Input.GetKey(_down))
        {
            _wightPosition = -1;
        }
        else
        {
            _wightPosition = 0;
        }

        Vector3 direction = new Vector3(_heightPosition, _wightPosition, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.z >= _maxWightPosition)
        {
            transform.position = new Vector3(transform.position.x, _height, _maxWightPosition);
        }
        else if(transform.position.z <= _minWightPosition)
        {
            transform.position = new Vector3(transform.position.x, _height, _minWightPosition);
        }

        if (transform.position.x >= _maxHeightPosition)
        {
            transform.position = new Vector3(_maxHeightPosition, _height, transform.position.z);
        }
        else if (transform.position.x <= _minHeightPosition)
        {
            transform.position = new Vector3(_minHeightPosition, _height, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, _height, transform.position.z);
    }
}