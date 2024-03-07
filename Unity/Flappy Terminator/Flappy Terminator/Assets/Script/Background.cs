using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject _backgraundFirst;
    [SerializeField] private GameObject _backgraundSecond;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _endPoint;
    [SerializeField] private float _speed;

    private void Update()
    {
        _backgraundFirst.transform.Translate(Vector2.left * _speed);
        _backgraundSecond.transform.Translate(Vector2.left * _speed);

        if(_backgraundFirst.transform.position.x <= _endPoint.transform.position.x)
        {
            _backgraundFirst.transform.position = _startPoint.transform.position;
        }

        if (_backgraundSecond.transform.position.x <= _endPoint.transform.position.x)
        {
            _backgraundSecond.transform.position = _startPoint.transform.position;
        }
    }
}