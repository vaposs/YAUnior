using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _growthRate;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMove;

    private void Start()
    {
        StartCoroutine(Scale());
        StartCoroutine(Rotation());
        StartCoroutine(Mover());
    }

    private IEnumerator Scale()
    {
        while(true)
        {
            _cubeTransform.localScale += new Vector3(_growthRate, _growthRate, _growthRate);

            if (_cubeTransform.localScale.x > _maxScale)
            {
                _growthRate = _growthRate * -1;
            }
            else if (_cubeTransform.localScale.x < _minScale)
            {
                _growthRate = _growthRate * -1;
            }

            yield return null;
        }
    }

    private IEnumerator Rotation()
    {
        while(true)
        {
            _cubeTransform.Rotate(_cubeTransform.rotation.x, _speedRotation * Time.deltaTime, _cubeTransform.rotation.z);

            yield return null;
        }
    }

    private IEnumerator Mover()
    {
        while(true)
        {
            _cubeTransform.Translate(_speedMove,0,0);

            yield return null;
        }
    }
}
