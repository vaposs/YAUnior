using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backgraundFirst;
    [SerializeField] private SpriteRenderer _backgraundSecond;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        _backgraundFirst.transform.Translate(Vector2.left * _speed * Time.deltaTime);
        _backgraundSecond.transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_backgraundFirst.transform.position.x <= _endPoint.transform.position.x)
        {
            _backgraundFirst.transform.position = _startPoint.transform.position;
        }

        if (_backgraundSecond.transform.position.x <= _endPoint.transform.position.x)
        {
            _backgraundSecond.transform.position = _startPoint.transform.position;
        }
    }
}